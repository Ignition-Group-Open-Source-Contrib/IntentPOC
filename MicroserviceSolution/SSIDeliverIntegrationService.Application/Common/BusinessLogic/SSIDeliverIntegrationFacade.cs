using Azure.Messaging.EventGrid.SystemEvents;
using IgnitionGroup.AzureStorageQueueHelper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using SSIDeliverIntegrationService.Application.Common.Configuration;
using SSIDeliverIntegrationService.Application.Common.Eventing;
using SSIDeliverIntegrationService.Application.Common.Helper;
using SSIDeliverIntegrationService.Application.ViewModels;
using SSIDeliverIntegrationService.Domain.Common;
using SSIDeliverIntegrationService.Domain.Entities.Ord;
using SSIDeliverIntegrationService.Domain.Entities.Stock;
using SSIDeliverIntegrationService.Domain.Repositories.Admin;
using SSIDeliverIntegrationService.Domain.Repositories.Cust;
using SSIDeliverIntegrationService.Domain.Repositories.Ord;
using SSIDeliverIntegrationService.Domain.Repositories.Stock;
using SSIDeliverIntegrationService.Eventing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using static SSIDeliverIntegrationService.Application.Common.Enum.Enumerator;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;

namespace SSIDeliverIntegrationService.Application.Common.BusinessLogic
{
    public class SSIDeliverIntegrationFacade : ISSIDeliverIntegrationFacade
    {
        private readonly IOrderDeliveryRepository _orderDeliveryRepository;
        private readonly IIDeliverOrderInfoRepository _iDeliverOrderInfoRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IConfigurationSettings _configurationSettings;
        private readonly IWorkflowStorageFactory _workflowStorageFactory;
        private readonly IDeliveryTypeRepository _deliveryTypeRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IIDeliverProductChannelMappingRepository _iDeliverProductChannelMappingRepository;
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IVASXProviderSpecificRepository _vASXProviderSpecificRepository;
        private readonly IOrderStatusHistoryRepository _orderStatusHistoryRepository;
        private readonly IOrderAnnotationRepository _orderAnnotationRepository;
        private readonly IEventBus _eventBus;
        private readonly IProductRepository _productRepository;
        private readonly IProductDimensionsRepository _productDimensionsRepository;

        public SSIDeliverIntegrationFacade(IOrderDeliveryRepository orderDeliveryRepository,
            IIDeliverOrderInfoRepository iDeliverOrderInfoRepository, IOrderItemRepository orderItemRepository,
            IConfigurationSettings configurationSettings, IWorkflowStorageFactory workflowStorageFactory,
            IDeliveryTypeRepository deliveryTypeRepository, ICustomerAddressRepository customerAddressRepository,
            IIDeliverProductChannelMappingRepository iDeliverProductChannelMappingRepository,
            IStockItemRepository stockItemRepository, IVASXProviderSpecificRepository vASXProviderSpecificRepository,
            IOrderStatusHistoryRepository orderStatusHistoryRepository, IOrderAnnotationRepository orderAnnotationRepository,
            IEventBus eventBus,
            IProductRepository productRepository,
            IProductDimensionsRepository productDimensionsRepository)
        {
            _orderDeliveryRepository = orderDeliveryRepository;
            _iDeliverOrderInfoRepository = iDeliverOrderInfoRepository;
            _orderItemRepository = orderItemRepository;
            _configurationSettings = configurationSettings;
            _workflowStorageFactory = workflowStorageFactory;
            _deliveryTypeRepository = deliveryTypeRepository;
            _customerAddressRepository = customerAddressRepository;
            _iDeliverProductChannelMappingRepository = iDeliverProductChannelMappingRepository;
            _stockItemRepository = stockItemRepository;
            _vASXProviderSpecificRepository = vASXProviderSpecificRepository;
            _orderStatusHistoryRepository = orderStatusHistoryRepository;
            _orderAnnotationRepository = orderAnnotationRepository;
            _eventBus = eventBus;
            _productRepository = productRepository;
            _productDimensionsRepository = productDimensionsRepository;
        }

        public async Task ProcessStockOrder(IDeliverOrderCallBackAPIRequest request, CancellationToken cancellationToken)
        {
            // Fetch IDeliver Order info by IDeliverOrderId from SS
            var iDeliverorder =
                await _iDeliverOrderInfoRepository.FindAsync(x => x.IDeliverOrderId == request.IDeliverOrderId);
            if (iDeliverorder == null)
            {
                throw new Exception("Process Stock Order no ideliver order details found");
            }

            //Fetch order items by order id from ss
            var orderitems = await _orderItemRepository.FindAllAsync(x => x.OrderId == iDeliverorder.OrderId);
            if (orderitems == null || !orderitems.Any())
            {
                throw new Exception("Process Stock Order no order items detail found");

            }

            foreach (var item in request.OrderDetails)
            {
                // Check OrderReference exists or not in SS provided by IDeliver                 
                if (!orderitems.Any(i => i.OrderReference == item.OrderRef?.Trim()))
                {
                    continue;
                }

                // Get Order Item from SS by OrderRef given by IDeliver
                var orderItem = orderitems.Where(i => i.OrderReference == item.OrderRef).FirstOrDefault();
                if (orderItem == null)
                {
                    continue;
                }

                item.OrderItemId = orderItem.OrderItemId;
                int orderStatusToUpdate;

                // Insert/Update order status into OrderItem and OrderStatusHistory

                if (orderItem.OrderItemId == item.OrderItemId &&
                    orderItem.OrderStatusDetailId != (int)OrderStatusDetail.DispatchOrdered)
                {
                    // Update order status in order item
                    orderStatusToUpdate = (int)OrderStatusDetail.DispatchOrdered;
                    UpdateOrderItemStatus(orderItem, orderStatusToUpdate);
                }

                // Update order status in order status history
                var updateStatusHistory = new UpdateStatusHistoryRequest
                {
                    OrderItemId = item.OrderItemId,
                    StatusDetailId = (int)OrderStatusDetail.DispatchOrdered,
                    StatusMessage = "Order status has been updated from IDeliver"
                };
                await SetOrderStatusHistory(updateStatusHistory);


                // Check WayBillNumber is not null or empty given by IDeliver
                if (!string.IsNullOrEmpty(request.WayBillNumber?.Trim()))
                {
                    // Insert/Update into OrderDelivery                        
                    await InsertUpdateDeliveryOrder(iDeliverorder.OrderId, request.WayBillNumber, item,
                        cancellationToken);
                }

                // Check SerialNumber is not null or empty given by IDeliver
                item.SerialNumber = item.SerialNumber?.Trim();

                if (!string.IsNullOrEmpty(item.SerialNumber))
                {
                    // Insert/Update into StockItem                      
                    await InsertUpdateStockItem(item);
                }

                // Check serial number length is greater than 16
                if (item.SerialNumber.Length > 16)
                {
                    // Insert/Update into VASXProviderSpecific                       
                    await InsertUpdateVasXProviderSpecific(item);
                }

                await UpdateIDeliverOrderInfo(iDeliverorder.IDeliverOrderId.Value,
                    (int)IDeliverOrderStatus.Dispached);

                var skipDODProviders = _configurationSettings.SkipOutForDeliveryProviders.Any()
                    ? _configurationSettings.SkipOutForDeliveryProviders.Split(',').Select(int.Parse).ToList()
                    : new List<int>();

                //Skip the providers to resume the workflow directly to delivery out for delivery status
                if (!skipDODProviders.Contains(orderItem.OrderTypeId))
                {
                    //Update to Delivery Out For Delivery Status

                    if (orderItem.OrderItemId == item.OrderItemId &&
                        orderItem.OrderStatusDetailId != (int)OrderStatusDetail.OutforDelivery)
                    {
                        // Update order status in order item
                        orderStatusToUpdate = (int)OrderStatusDetail.OutforDelivery;
                        UpdateOrderItemStatus(orderItem, orderStatusToUpdate);
                    }

                    // Update order status to delivery out for delivey in order status history
                    var updateOutForDeliveryStatusHistory = new UpdateStatusHistoryRequest
                    {
                        OrderItemId = item.OrderItemId,
                        StatusDetailId = (int)OrderStatusDetail.OutforDelivery,
                        StatusMessage = request.WayBillNumber
                    };

                    await SetOrderStatusHistory(updateOutForDeliveryStatusHistory);

                }

                // If order is not in marketic then it will be processed from Silver Surfer otherwise from Marketic
                //if (!orderItem.IsMarketic.GetValueOrDefault(false))
                //{
                //    //Add into Comms queue
                //    await ProcessComms(orderItem.OrderItemId);
                //}
                //else
                //{
                //    // Resume workflow
                //    ResumeOrderRequestModel resumeOrderRequestModel = new ResumeOrderRequestModel()
                //    {
                //        OrderItemId = orderItem.OrderItemId,
                //        OrderStatusDetailId = orderStatusToUpdate
                //    };

                //    await ResumeOrder(resumeOrderRequestModel);
                //}
            }


            if (!string.IsNullOrEmpty(request.SaleAgreement))
            {
                //Upload the Sale Agreement
                var saleAgreementModel = new UploadPdfViewModel
                {
                    IDeliverOrderId = iDeliverorder.IDeliverOrderId.Value,
                    Base64Encoded = request.SaleAgreement,
                    BlobContainerName = _configurationSettings.SaleAgreementUploadBlobName,
                    FileName = Constants.SaleAgreement,
                    FileType = Constants.PdfType
                };

                _eventBus.Publish(new UploadPdfFileEvent { SaleAgreementDetails = saleAgreementModel });
                //_ = daprApi.ProcessUploadPdfFile(saleAgreementModel);
            }
        }

        private async Task ResumeOrder(ResumeOrderRequestModel resumeOrderRequestModel)
        {
            try
            {

                // var response = await daprApi.ResumeOrder(resumeOrderRequestModel);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateOrderItemStatus(OrderItem orderItem, int orderStatusToUpdate)
        {

            orderItem.OrderStatusDetailId = orderStatusToUpdate;


        }

        private async Task ProcessComms(int orderItemId)
        {
            try
            {
                var commsStateModel = new CommsState
                {
                    Id = orderItemId,
                    ActionType = ActionTypeEnum.None,
                    CommsType = (int)CommsType.StatusComms
                };
                await _workflowStorageFactory.Create(_configurationSettings.AzureStorageConnection, _configurationSettings.CommsQueue).AddItemToQueue(commsStateModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task UpdateIDeliverOrderInfo(int id, int iDeliverOrderStatus)
        {

            var iDeliverOrderInfo = await _iDeliverOrderInfoRepository.FindAsync(i => i.IDeliverOrderId == id);
            if (iDeliverOrderInfo == null || iDeliverOrderInfo.IDeliverOrderInfoId == 0) throw new Exception();


            iDeliverOrderInfo.IDeliverOrderStatusId = iDeliverOrderStatus;
            iDeliverOrderInfo.UpdatedByUserId = 1;
            iDeliverOrderInfo.UpdatedOnDate = DateTime.Now;



        }

        private async Task InsertUpdateVasXProviderSpecific(OrderDetail item)
        {
            var vasxProviderSpecific =
                await _vASXProviderSpecificRepository.FindAsync(x => x.OrderItemId == item.OrderItemId);
            if (vasxProviderSpecific == null)
            {
                // Insert VasX Provider Specific
                vasxProviderSpecific = new VASXProviderSpecific
                {
                    OrderItemId = item.OrderItemId,
                    SubscriberUid = string.Empty,
                    Iccid = item.SerialNumber
                };
                _vASXProviderSpecificRepository.Add(vasxProviderSpecific);
            }
            else
            {
                // Update VasX Provider Specific (Note: Keep current values if IDeliver request data is null or empty)
                vasxProviderSpecific.SubscriberUid = vasxProviderSpecific.SubscriberUid;
                vasxProviderSpecific.Iccid = item.SerialNumber;
            }
        }

        private async Task InsertUpdateStockItem(OrderDetail item)
        {
            // Get product id and price both, if IDeliver sending the price as 0 set the price from SS
            var ideliverProductChannelMapping =
                await _iDeliverProductChannelMappingRepository.FindAsync(x =>
                    x.IDeliverProductId == item.IDeliverProductId);
            var productId = ideliverProductChannelMapping?.ProductId ?? 0;
            if (productId <= 0)
            {
                throw new Exception();
            }

            var product = ideliverProductChannelMapping?.Product;

            // Check if not getting product by IDeliverProductId from SS
            if (product == null)
            {
                throw new Exception();
            }

            // Get Stock Item from SS by Serial Number and OrderItemId given by IDeliver
            var stockItem = await _stockItemRepository.FindAsync(x =>
                x.SerialNumber == item.SerialNumber && x.OrderItemId == item.OrderItemId);

            // If Stock Item can be found by SerialNumber and OrderItemId in SS then update otherwise insert
            if (stockItem != null)
            {
                //Update Stock Item

                stockItem.SerialNumber = item.SerialNumber;
                stockItem.Price = item.ProductPrice ?? product.Price;
                stockItem.ProductId = product.ProductId;
                stockItem.ReturnStatus = 0;
                stockItem.Sim = string.Empty;
                stockItem.Received = 0;
                stockItem.StockStatusId = 1;
                stockItem.OrderItemId = item.OrderItemId;

            }
            else
            {
                //Insert Stock Item
                var newStockItem = new StockItem
                {
                    SerialNumber = item.SerialNumber,
                    Price = item.ProductPrice ?? product.Price,
                    ProductId = product.ProductId,
                    ReturnStatus = 0,
                    Sim = string.Empty,
                    Received = 0,
                    StockStatusId = 1,
                    OrderItemId = item.OrderItemId
                };

                _stockItemRepository.Add(newStockItem);
            }
        }

        private async Task InsertUpdateDeliveryOrder(int orderId, string wayBillNumber, OrderDetail item, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderItemRepository.FindAsync(x => x.Order.OrderId == orderId);
            if (orderDetails.Order.CustomerId > 0)
            {
                var customerAddress = await _customerAddressRepository.FindAsync(i =>
                    i.CustomerId == orderDetails.Order.CustomerId && i.AddressTypeId == (int)AddressType.Delivery);
                if (customerAddress.CustomerAddressId == 0)
                {
                    throw new Exception();
                }

                var orderDelivery = await _orderDeliveryRepository.FindAsync(x => x.OrderItemId == orderDetails.OrderItemId, cancellationToken);
                var deliveryType = await _deliveryTypeRepository.FindAllAsync(cancellationToken);
                var deliveryTypeId = deliveryType?.FirstOrDefault()?.DeliveryTypeId ?? 0;
                if (deliveryTypeId == 0)
                {
                    throw new Exception();
                }

                // Update Order delivery
                if (orderDelivery != null)
                {
                    orderDelivery.CustomerAddressId = customerAddress.CustomerAddressId;
                    orderDelivery.DeliveryTypeId = deliveryTypeId;
                    orderDelivery.WayBillNumber = wayBillNumber;
                    orderDelivery.ConsignmentId = wayBillNumber;
                    orderDelivery.DispatchDate = DateTime.Now;
                    orderDelivery.OrderStatusDetailId = (int)OrderStatusDetail.DispatchOrdered;

                }
                //Insert Order deliver
                else
                {
                    var orderDeliveryRequest = new OrderDelivery()
                    {
                        OrderItemId = item.OrderItemId,
                        CustomerAddressId = customerAddress.CustomerAddressId,
                        DeliveryTypeId = deliveryTypeId,
                        WayBillNumber = wayBillNumber,
                        ConsignmentId = wayBillNumber,
                        OrderStatusDetailId = (int)OrderStatusDetail.DispatchOrdered,
                        DispatchDate = DateTime.Now
                    };

                    _orderDeliveryRepository.Add(orderDeliveryRequest);
                }
            }
        }

        private async Task SetOrderStatusHistory(UpdateStatusHistoryRequest updateStatusHistory)
        {

            OrderStatusHistory lastStatusHistory;
            lastStatusHistory = await _orderStatusHistoryRepository.FindAsync(i => i.OrderItemId == updateStatusHistory.OrderItemId && i.OrderStatusDetailId == updateStatusHistory.StatusDetailId, i => i.OrderByDescending(x => x.Occured));
            if (lastStatusHistory != null && lastStatusHistory.Annotation == updateStatusHistory.StatusMessage)
            {
                lastStatusHistory.Occured = DateTime.Now;

            }
            else
            {
                var orderStatusHistory = new OrderStatusHistory()
                {
                    OrderItemId = updateStatusHistory.OrderItemId,
                    Occured = DateTime.Now,
                    Annotation = updateStatusHistory.StatusMessage,
                    OrderStatusDetailId = updateStatusHistory.StatusDetailId,
                    EmailCommSentStatusId = (int)CommSentStatus.Pending,
                    SmscommSentStatusId = (int)CommSentStatus.Pending
                };
                _orderStatusHistoryRepository.Add(orderStatusHistory);
                var orderAnnotation = new OrderAnnotation()
                {
                    OrderItemId = updateStatusHistory.OrderItemId,
                    UserId = 1,
                    AnnotationDate = DateTime.Now,
                    Details = updateStatusHistory.StatusMessage,
                    AnnotationTypeId = 1
                };
                _orderAnnotationRepository.Add(orderAnnotation);

            }



        }

        public async Task UploadPdfFile(UploadPdfViewModel uploadPdfViewModel)
        {
            try
            {

                string filename = $"{uploadPdfViewModel.FileName}_{uploadPdfViewModel.IDeliverOrderId}_{DateTime.Now.Ticks}";

                // Retrieve storage account from connection string.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configurationSettings.AzureStorageConnection);

                // Create the blob client.
                var blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve a reference to a container.
                var container = blobClient.GetContainerReference(uploadPdfViewModel.BlobContainerName);

                // Create the container if it doesn't already exist.
                await container.CreateIfNotExistsAsync();

                //Provide public access to blob container
                var permission = new BlobContainerPermissions();
                permission.PublicAccess = BlobContainerPublicAccessType.Blob;
                await container.SetPermissionsAsync(permission);

                // Retrieve reference to a blob named "myblob".
                var blockBlob = container.GetBlockBlobReference(filename);

                //Set the content type as pdf
                byte[] byteArray = Convert.FromBase64String(uploadPdfViewModel.Base64Encoded);

                MemoryStream stream = new MemoryStream(byteArray);

                var contentType = uploadPdfViewModel.FileType == Constants.TiffType ? Constants.ImageContentType : Constants.PDFContentType;
                blockBlob.Properties.ContentType = $"{contentType}/{uploadPdfViewModel.FileType}";

                // Upload the file
                await blockBlob.UploadFromStreamAsync(stream);
                var uri = blockBlob.StorageUri.PrimaryUri.AbsoluteUri;


                //Call CEP external source event
                //var externalSourceEvent = new ExternalSourceEventViewModel
                //{
                //    IDeliverOrderId = uploadPdfViewModel.IDeliverOrderId,
                //    TriggerFor = uploadPdfViewModel.FileName,
                //    Uri = uri
                //};
                //await ExternalSourceEventTrigger(externalSourceEvent);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Task<bool> VerifyInValidOrder(int orderId, List<int> iDeliverProviders)
        {
            return _orderItemRepository.AnyAsync(x => x.OrderId == orderId && !iDeliverProviders.Contains(x.OrderTypeId));
        }

        public Task<List<int>> GetIDeliverOrderItems(int orderId, List<int> iDeliverProviders, List<int> skipOrderStatus)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyIDeliverOrder(int orderId, List<int> iDeliverProviders)
        {
            return _orderItemRepository.AnyAsync(x => x.OrderId == orderId && iDeliverProviders.Contains(x.OrderTypeId));
        }

        public Task<bool> VerifyInValidOrderStatus(int orderId, List<int> iDeliverProviders, List<int> skipOrderStatus)
        {
            return _orderItemRepository.AnyAsync(x => x.OrderId == orderId && iDeliverProviders.Contains(x.OrderTypeId) && skipOrderStatus.Contains(x.OrderStatusDetailId));
        }

        public async Task PlaceSaleOnIDeliver(int orderId, IEnumerable<int> orderItemIds, CancellationToken cancellationToken)
        {

            var (orderDetails, errorMessage) = await GetSSOrderDetails(orderId, orderItemIds);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                await SetOrderItemFailedStatus(orderId, orderItemIds, errorMessage);
                throw new Exception(errorMessage);
            }
            if (orderDetails == null)
            {
                await SetOrderItemFailedStatus(orderId, orderItemIds, "Place Sale On IDeliver order details not found");
                throw new Exception($"Place Sale On IDeliver order details not found for orderId {orderId}");
            }
            var response = await PlaceSSOrderOnIDeliver(orderDetails);
            var result = response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var saleOrderErrorMessage = JsonConvert.DeserializeObject<ErrorResponseModel>(result.Result);
                var error = saleOrderErrorMessage?.ResponseException?.ExceptionMessage ?? "Error occurred while placing sale order on ideliver";
                await SetOrderItemFailedStatus(orderId, orderItemIds, error);
                throw new Exception($"Error occurred while placing sale on ideliver for orderId {orderId} error message {saleOrderErrorMessage}");
            }
            var saleOrderResult = JsonConvert.DeserializeObject<CreateUpdateSaleOrderResponseModel>(result.Result.ToString());
            if (saleOrderResult.Id <= 0)
            {
                await SetOrderItemFailedStatus(orderId, orderItemIds, "Place sale on Ideliver error occurred sale order id is less than zero");
                throw new Exception($"Error occurred after placing sale on ideliver the sale order id is less than zero for orderId {orderId}");
            }
            await AddIDeliverOrderInfo(orderId, saleOrderResult.Id);
            await SetOrderItemSuccessStatus(orderId, orderItemIds, "Order Created Successfully on IDeliver");


        }

        private Task SetOrderItemSuccessStatus(int orderId, IEnumerable<int> orderItemIds, string v)
        {
            throw new NotImplementedException();
        }

        private Task AddIDeliverOrderInfo(int orderId, int id)
        {
            throw new NotImplementedException();
        }

        private async Task<HttpResponseMessage> PlaceSSOrderOnIDeliver(CreateUpdateSaleOrderRequestModel orderDetails)
        {
            throw new NotImplementedException();
        }

        private Task SetOrderItemFailedStatus(int orderId, IEnumerable<int> orderItemIds, string v)
        {
            throw new NotImplementedException();
        }

        private Task<(CreateUpdateSaleOrderRequestModel, string)> GetSSOrderDetails(int orderId, IEnumerable<int> orderItemIds)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ProcessSSIDeliverOrders(SSIDeliverOrderViewModel ssIDeliverOrderViewModel)
        {
            _eventBus.Publish(new PlaceSaleOnIDeliverEvent { OrderId = ssIDeliverOrderViewModel.OrderId, OrderItems = ssIDeliverOrderViewModel.OrderItemIds });
            return await Task.FromResult($"PlaceSaleOnIDeliverEvent published successfully for {ssIDeliverOrderViewModel.OrderId}");

        }

        public async Task<(CreateProductRequestModel, string)> GetProductDetails(int productId)
        {
            try
            {
                var productDetails = await _productRepository.FindByIdAsync(productId);
                if (productDetails == null)
                {
                    return (null, "Get SS Product Details no product details found");
                }

                var productDimensions = await _productDimensionsRepository.FindByProductIdAsync(productId);
                if (productDimensions == null)
                {
                    // LOG: Get SS Product Dimension Details no product details found;
                }

                var response = productDetails.ConvertIntoProductRequest(productDimensions);
                var channelId = await _iDeliverProductChannelMappingRepository.FindChannelIdByProductId(productId);
                if (channelId <= 0)
                {
                    return (null, "Get SS Product Details no channel product mapping found");
                }
                response.Channel_id = channelId;
                return (response, string.Empty);
            }
            catch (Exception ex)
            {
                return (null, $"Exception occured while getting ss product details {ex.GetBaseException().Message}");
            }
        }

        public async Task<UpdateProductRequestModel> ConvertToUpdateProductRequest(CreateProductRequestModel productDetails)
        {
            try
            {
                return productDetails.ConvertIntoUpdateProductRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
