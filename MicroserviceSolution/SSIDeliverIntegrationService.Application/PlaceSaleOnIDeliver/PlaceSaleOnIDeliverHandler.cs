using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Threading;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using IgnitionGroup.AzureStorageQueueHelper;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SSIDeliverIntegrationService.Application.Common.Helper;
using SSIDeliverIntegrationService.Application.IDeliverService;
using SSIDeliverIntegrationService.Application.ViewModels;
using SSIDeliverIntegrationService.Domain.Entities.Ord;
using SSIDeliverIntegrationService.Domain.Repositories;
using SSIDeliverIntegrationService.Domain.Repositories.Camp;
using SSIDeliverIntegrationService.Domain.Repositories.Cust;
using SSIDeliverIntegrationService.Domain.Repositories.Deals;
using SSIDeliverIntegrationService.Domain.Repositories.Ord;
using SSIDeliverIntegrationService.Domain.Repositories.Stock;
using static SSIDeliverIntegrationService.Application.Common.Enum.Enumerator;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.PlaceSaleOnIDeliver
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PlaceSaleOnIDeliverHandler : IRequestHandler<PlaceSaleOnIDeliver>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IVwGetCustomerAddressRepository _vwGetCustomerAddressRepository;
        private readonly ICustomerContactRepository _customerContactRepository;
        private readonly IIDeliverCampaignChannelMappingRepository _iDeliverCampaignChannelMappingRepository;
        private readonly IDealProductMappingRepository _dealProductMappingRepository;
        private readonly IProductRepository _productRepository;
        private readonly IIDeliverProductChannelMappingRepository _iDeliverProductChannelMappingRepository;
        private readonly IDealRepository _dealRepository;
        private readonly ITariffRepository _tariffRepository;
        private readonly IOrderStatusHistoryRepository _orderStatusHistoryRepository;
        private readonly IOrderAnnotationRepository _orderAnnotationRepository;
        private readonly IWorkflowStorageFactory _workflowStorageFactory;
        private readonly IConfiguration _configuration;
        private readonly IIDeliverClient _iDeliverClient;
        private readonly ICampaignIDeliverCourierMappingRepository _iDeliverCampaignCourierMappingRepository;
        private readonly IIDeliverOrderInfoRepository _iDeliverOrderInfoRepository;

        [IntentManaged(Mode.Ignore)]
        public PlaceSaleOnIDeliverHandler(IOrderRepository orderRepository
            , IOrderItemRepository orderItemRepository
            , ICustomerRepository customerRepository
            , IVwGetCustomerAddressRepository vwGetCustomerAddressRepository
            , ICustomerContactRepository customerContactRepository
            , IIDeliverCampaignChannelMappingRepository iDeliverCampaignChannelMappingRepository
            , IDealProductMappingRepository dealProductMappingRepository
            , IProductRepository productRepository
            , IIDeliverProductChannelMappingRepository iDeliverProductChannelMappingRepository
            , IDealRepository dealRepository
            , ITariffRepository tariffRepository
            , IOrderStatusHistoryRepository orderStatusHistoryRepository
            , IOrderAnnotationRepository orderAnnotationRepository
            , IWorkflowStorageFactory workflowStorageFactory
            , IConfiguration configuration
            , IIDeliverClient iDeliverClient
            , ICampaignIDeliverCourierMappingRepository iDeliverCampaignCourierMappingRepository
            , IIDeliverOrderInfoRepository iDeliverOrderInfoRepository
            )
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _customerRepository = customerRepository;
            _vwGetCustomerAddressRepository = vwGetCustomerAddressRepository;
            _customerContactRepository = customerContactRepository;
            _iDeliverCampaignChannelMappingRepository = iDeliverCampaignChannelMappingRepository;
            _dealProductMappingRepository = dealProductMappingRepository;
            _productRepository = productRepository;
            _iDeliverProductChannelMappingRepository = iDeliverProductChannelMappingRepository;
            _dealRepository = dealRepository;
            _tariffRepository = tariffRepository;
            _orderStatusHistoryRepository = orderStatusHistoryRepository;
            _orderAnnotationRepository = orderAnnotationRepository;
            _workflowStorageFactory = workflowStorageFactory;
            _configuration = configuration;
            _iDeliverClient = iDeliverClient;
            _iDeliverCampaignCourierMappingRepository = iDeliverCampaignCourierMappingRepository;
            _iDeliverOrderInfoRepository = iDeliverOrderInfoRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(PlaceSaleOnIDeliver request, CancellationToken cancellationToken)
        {
            try
            {
                var (orderDetails, errorMessage) = await GetSSOrderDetails(request.OrderId, request.OrderItemIds.ToList(), cancellationToken);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    await SetOrderItemFailedStatus(request.OrderId, request.OrderItemIds.ToList(), errorMessage);
                    throw new ApiException(errorMessage, 400);
                }

                if (orderDetails == null)
                {
                    await SetOrderItemFailedStatus(request.OrderId, request.OrderItemIds.ToList(), "Place Sale On IDeliver order details not found");
                    throw new ApiException($"Place Sale On IDeliver order details not found for orderId {request.OrderId}", 400);
                }

                // convert orderDetails as IDeliverService request model
                IDeliverService.CreateUpdateSaleOrderRequestModel requestModel = new()
                {
                    Reference = orderDetails.Reference,
                    Recipient_name = orderDetails.Recipient_name,
                    Recipient_id = orderDetails.Recipient_id,
                    Recipient_email = orderDetails.Recipient_email,
                    Recipient_tel_1 = orderDetails.Recipient_tel_1,
                    Recipient_tel_2 = orderDetails.Recipient_tel_2,
                    Address_building = orderDetails.Address_building,
                    Address_company = orderDetails.Address_company,
                    Address_line_1 = orderDetails.Address_line_1,
                    Address_line_2 = orderDetails.Address_line_2,
                    Address_suburb = orderDetails.Address_suburb,
                    Address_city = orderDetails.Address_city,
                    Address_province = orderDetails.Address_province,
                    Address_postcode = orderDetails.Address_postcode,
                    Residential_address_building = orderDetails.Residential_address_building,
                    Residential_address_line_1 = orderDetails.Residential_address_line_1,
                    Residential_address_line_2 = orderDetails.Residential_address_line_2,
                    Residential_address_suburb = orderDetails.Residential_address_suburb,
                    Residential_address_city = orderDetails.Residential_address_city,
                    Residential_address_province = orderDetails.Residential_address_province,
                    Residential_address_postcode = orderDetails.Residential_address_postcode,
                    Extra_info_1 = orderDetails.Extra_info_1,
                    Extra_info_2 = orderDetails.Extra_info_2,
                    Delivery_notes = orderDetails.Delivery_notes,
                    Channel_id = orderDetails.Channel_id,
                    Warehouse_id = orderDetails.Warehouse_id,
                    Sale_order_items = orderDetails.Sale_order_items.Select(x => new IDeliverService.SaleOrderItemsRequestModel
                    {
                        Sku = x.Sku,
                        Qty = x.Qty,
                        Description = x.Description,
                    }).ToList(),
                };

                var saleOrderResult = await PlaceSSOrderOnIDeliver(requestModel);
                if (saleOrderResult == null)
                {
                    await SetOrderItemFailedStatus(request.OrderId, request.OrderItemIds.ToList(), "Error occurred while placing sale order on ideliver");
                    throw new ApiException($"Error occurred while placing sale on ideliver for orderId {request.OrderId}", 400);
                }

                if (saleOrderResult.Id <= 0)
                {
                    await SetOrderItemFailedStatus(request.OrderId, request.OrderItemIds.ToList(), "Place sale on Ideliver error occurred sale order id is less than zero");
                    throw new ApiException($"Error occurred after placing sale on ideliver the sale order id is less than zero for orderId {request.OrderId}", 400);
                }

                // Here update IDeliver order info
                await UpdateIDeliverOrderInfo(request.OrderId, saleOrderResult.Id);
                await SetOrderItemSuccessStatus(request.OrderId, request.OrderItemIds.ToList(), "Order Created Successfully on IDeliver");
                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new ApiException($"An unexpected error has occured due to {ex.GetBaseException().Message} , please contact your administrator.", 400);
            }
        }

        private async Task<(ViewModels.CreateUpdateSaleOrderRequestModel, string)> GetSSOrderDetails(int orderId, List<int> orderItemIds, CancellationToken cancellationToken = default)
        {
            try
            {
                var orderDetails = await _orderRepository.FindByIdAsync(orderId, cancellationToken);
                if (orderDetails == null)
                {
                    return (null, "No order details found");
                }

                var customerDetails = await _customerRepository.FindByIdAsync(orderDetails.CustomerId, cancellationToken);
                if (customerDetails == null)
                {
                    return (null, "No customer details found");
                }

                var customerAddress = await _vwGetCustomerAddressRepository.FindByCustomerIdAsync(customerDetails.CustomerID);
                if (customerAddress == null || !customerAddress.Any())
                {
                    return (null, "No customer address found");
                }

                var customerContact = await _customerContactRepository.FindByCustomerIdAsync(customerDetails.CustomerID);
                if (customerContact == null || !customerContact.Any())
                {
                    return (null, "No customer contact found");
                }

                var channelId = await _iDeliverCampaignChannelMappingRepository.FindChannelIdByCampaignId(orderDetails.CampaignId);

                if (channelId <= 0)
                {
                    return (null, "No campaign channel mapping found");
                }

                var convertToCreateSaleRequest = new ConvertToPlaceSaleOrderRequest
                {
                    OrderDetails = orderDetails,
                    CustomerDetails = customerDetails,
                    CustomerContactDetails = customerContact,
                    CustomerAddressDetails = customerAddress
                };

                var saleOrderRequest = convertToCreateSaleRequest.ConvertIntoCreateSaleRequest();
                if (saleOrderRequest == null)
                {
                    return (null, "Enable to convert into create sale request");
                }

                saleOrderRequest.Channel_id = channelId;
                var (orderItems, errorMessage) = await GetSSOrderItems(orderItemIds);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return (null, errorMessage);
                }

                if (orderItems == null || orderItems.SaleOrderItems?.Any() == false)
                {
                    return (null, "No order item details found");
                }

                saleOrderRequest.Sale_order_items = orderItems.SaleOrderItems;
                saleOrderRequest.Extra_info_1 = orderItems.TariffDetails;

                return (saleOrderRequest, string.Empty);
            }
            catch (Exception ex)
            {
                return (null, $"Exception occured while getting ss order details {ex.GetBaseException().Message}");
            }
        }

        private async Task<(SaleOrderItemViewModel, string)> GetSSOrderItems(List<int> orderItemIds)
        {
            try
            {
                var tariffDetails = string.Empty;
                List<ViewModels.SaleOrderItemsRequestModel> SaleOrderItemsRequestModel = new List<ViewModels.SaleOrderItemsRequestModel>();

                foreach (var orderItemId in orderItemIds)
                {
                    var orderItem = await _orderItemRepository.FindByIdAsync(orderItemId);
                    if (orderItem == null || orderItem.OrderItemId <= 0)
                    {
                        return (null, "No orderItem found");
                    }

                    var productIds = await _dealProductMappingRepository.FindProductIdsByDealId(orderItem.DealId);
                    if (!productIds.Any())
                    {
                        return (null, $"No deal product mapping found for order reference {orderItem.OrderReference}");
                    }

                    foreach (var productId in productIds)
                    {
                        if (productId.GetValueOrDefault(0) > 0)
                        {
                            var productDetails = await _productRepository.FindByIdAsync(productId.Value);
                            if (productDetails == null || productDetails?.Active == 0)
                            {
                                return (null, $"No active product found for product Id {productId} and order reference {orderItem.OrderReference}");
                            }
                            var productChannelId = await _iDeliverProductChannelMappingRepository.FindChannelIdByProductId(productId.Value);
                            if (productChannelId <= 0)
                            {
                                return (null, $"No ideliver product channel mapping found for product {productDetails.Title} and order reference {orderItem.OrderReference} ");
                            }
                            var createOrderItemRequest = new ViewModels.SaleOrderItemsRequestModel
                            {
                                Sku = productId.ToString(),
                                Qty = Constants.Quantity,
                                Description = orderItem.OrderReference
                            };
                            SaleOrderItemsRequestModel.Add(createOrderItemRequest);
                        }
                        else
                        {
                            return (null, "Product id is not greater than zero");
                        }
                    }

                    var tariffId = await _dealRepository.FindTariffIdByDealId(orderItem.DealId);
                    if (tariffId.GetValueOrDefault(0) > 0)
                    {
                        var tariff = await _tariffRepository.FindByIdAsync(tariffId.Value);
                        if (string.IsNullOrEmpty(tariffDetails))
                        {
                            tariffDetails = $"{tariff.Description} (R{tariff.Price})";
                        }
                        else
                        {
                            tariffDetails += $", {tariff.Description} (R{tariff.Price})";
                        }
                    }
                    else
                    {
                        return (null, "Tariff id is not greater than zero");
                    }
                }

                var saleOrderItemViewModel = new SaleOrderItemViewModel
                {
                    SaleOrderItems = SaleOrderItemsRequestModel,
                    TariffDetails = tariffDetails
                };

                return (saleOrderItemViewModel, string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SetOrderItemFailedStatus(int orderId, List<int> orderItemIds, string errorMessage)
        {
            try
            {
                var updateStatusRequest = new UpdateOrderItemStatusRequestModel
                {
                    OrderId = orderId,
                    OrderItemIds = orderItemIds,
                    OrderStatusDetailId = (int)OrderStatusDetail.DispatchWaiting,
                    StatusMessage = errorMessage
                };

                await UpdateOrderItemStatus(updateStatusRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateOrderItemStatus(UpdateOrderItemStatusRequestModel request)
        {
            try
            {
                foreach (var orderItemId in request.OrderItemIds)
                {
                    var orderItem = await _orderItemRepository.FindByIdAsync(orderItemId);
                    var isUpdated = await UpdateOrderItemStatusToDB(orderItem, request.OrderStatusDetailId);
                    if (isUpdated)
                    {
                        var updateStatusRequest = new UpdateStatusHistoryRequest
                        {
                            OrderItemId = orderItemId,
                            StatusDetailId = request.OrderStatusDetailId,
                            StatusMessage = request.StatusMessage
                        };

                        if (!await SetOrderStatusHistory(updateStatusRequest))
                        {
                            //TODO: SET ERROR LOGS
                        }

                        // If order is not in marketic then it will be processed from Silver Surfer otherwise from Marketic
                        if (!orderItem.IsMarketic.GetValueOrDefault(false))
                        {
                            if (request.OrderStatusDetailId != (int)OrderStatusDetail.DeliveryRTS)
                            {
                                var serviceFabricEvent = request.OrderStatusDetailId == (int)OrderStatusDetail.DeliveryDelivered ? (int)HandlerEnum.DeliveryHandler : (int)HandlerEnum.DispatchHandler;

                                await ProcessDispatchHandler(request.OrderItemIds.ToList(), serviceFabricEvent);
                            }

                            //Add into Comms queue
                            await ProcessComms(orderItem.OrderItemId);
                        }
                        else
                        {
                            // Resume workflow
                            ResumeOrderRequestModel resumeOrderRequestModel = new ResumeOrderRequestModel()
                            {
                                OrderItemId = orderItemId,
                                OrderStatusDetailId = request.OrderStatusDetailId
                            };

                            // TODO: need to add resumessorders service
                            // await ResumeOrder(resumeOrderRequestModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> UpdateOrderItemStatusToDB(OrderItem orderItem, int orderStatusDetailId)
        {
            try
            {
                orderItem.OrderStatusDetailId = orderStatusDetailId;
                _orderItemRepository.Update(orderItem);
                return (await _orderItemRepository.UnitOfWork.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<bool> SetOrderStatusHistory(UpdateStatusHistoryRequest updateStatusHistory)
        {
            try
            {
                OrderStatusHistory lastStatusHistory = await _orderStatusHistoryRepository.FindLastStatusHistoryAsync(updateStatusHistory.OrderItemId, updateStatusHistory.StatusDetailId);
                if (lastStatusHistory != null && lastStatusHistory.Annotation == updateStatusHistory.StatusMessage)
                {
                    lastStatusHistory.Occured = DateTime.Now;
                    _orderStatusHistoryRepository.Update(lastStatusHistory);
                    return (await _orderStatusHistoryRepository.UnitOfWork.SaveChangesAsync()) > 0;
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

                    return (await _orderStatusHistoryRepository.UnitOfWork.SaveChangesAsync()) > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task ProcessDispatchHandler(List<int> orderItemIds, int serviceFabricEvent)
        {
            try
            {
                foreach (var orderItemId in orderItemIds)
                {
                    await PopulateSSQueue(orderItemId, serviceFabricEvent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task PopulateSSQueue(int orderItemId, int serviceFabricEvent)
        {
            try
            {
                var eventStateModel = new ActorRaiseEventModel
                {
                    ServiceFabricEvent = (HandlerEnum)serviceFabricEvent,
                    OrderItemId = orderItemId
                };
                await _workflowStorageFactory.Create(_configuration.GetValue<string>("marketic:ssconnectionstrings:azurestorage"),
                    _configuration.GetValue<string>("marketic:ssideliver:actorresurrectionqueue")).AddItemToQueue(eventStateModel);
            }
            catch (Exception ex)
            {
                throw;
            }
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
                await _workflowStorageFactory.Create(_configuration.GetValue<string>("marketic:ssconnectionstrings:azurestorage")
                    , _configuration.GetValue<string>("marketic:ss:commsqueue")).AddItemToQueue(commsStateModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IDeliverService.CreateUpdateSaleOrderResponseModel> PlaceSSOrderOnIDeliver(IDeliverService.CreateUpdateSaleOrderRequestModel orderDetails)
        {
            try
            {
                orderDetails.Warehouse_id = _configuration.GetValue<int>("marketic:ideliver:warehouse");
                var saleOrderResult = await _iDeliverClient.CreateSaleOrderAsync(_configuration.GetValue<string>("marketic:ideliver:accesstoken"), orderDetails);
                return saleOrderResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SetOrderItemSuccessStatus(int orderId, List<int> orderItemIds, string message)
        {
            try
            {
                var updateStatusRequest = new UpdateOrderItemStatusRequestModel
                {
                    OrderId = orderId,
                    OrderItemIds = orderItemIds,
                    OrderStatusDetailId = (int)OrderStatusDetail.DispatchConsign,
                    StatusMessage = message
                };
                await UpdateOrderItemStatus(updateStatusRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task UpdateIDeliverOrderInfo(int orderId, int id)
        {
            try
            {
                int courierId = 0;

                //Fetch CampaignId by Order Id
                var order = await _orderRepository.FindByIdAsync(orderId);
                var campaignId = order?.CampaignId;
                if (campaignId > 0)
                {

                    //Fetch Courier Id from Campaign IDeliver Courier Mapping
                    var campaignCourierMapping = await _iDeliverCampaignCourierMappingRepository.FindByCampaignIdAsync(campaignId.Value);
                    courierId = campaignCourierMapping.Select(i => i.IdeliverCourierId).FirstOrDefault();
                }

                // Fetch IDeliverOrderInfo
                var iDeliverOrderInfo = await _iDeliverOrderInfoRepository.FindByOrderIdAsync(orderId, (int)IDeliverOrderStatus.Ready);

                if (iDeliverOrderInfo != null)
                {
                    // update IDeliverOrderInfo
                    iDeliverOrderInfo.OrderId = orderId;
                    iDeliverOrderInfo.IDeliverOrderId = id;
                    iDeliverOrderInfo.IDeliverOrderStatusId = (int)IDeliverOrderStatus.Ready;
                    iDeliverOrderInfo.CreatedByUserId = 1;
                    iDeliverOrderInfo.CourierId = courierId > 0 ? courierId : (int)Common.Enum.Enumerator.Courier.Skynet;

                    _iDeliverOrderInfoRepository.Update(iDeliverOrderInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}