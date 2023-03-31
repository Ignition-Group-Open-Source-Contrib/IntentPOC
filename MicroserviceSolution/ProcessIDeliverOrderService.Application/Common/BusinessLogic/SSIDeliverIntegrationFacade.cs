using IgnitionGroup.AzureStorageQueueHelper;
using Microsoft.Extensions.Configuration;
using ProcessIDeliverOrderService.Application.Common.Configuration;
using ProcessIDeliverOrderService.Application.ViewModels;
using ProcessIDeliverOrderService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProcessIDeliverOrderService.Application.Common.Enumerator.Enumerator;

namespace ProcessIDeliverOrderService.Application.Common.BusinessLogic
{
    public class SSIDeliverIntegrationFacade : ISSIDeliverIntegrationFacade
    {
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IIDeliverOrderInfoRepository iDeliverOrderInfoRepository;
        private readonly IConfigurationSettings configurationSettings;
        private readonly IWorkflowStorageFactory workflowStorageFactory;

        public SSIDeliverIntegrationFacade(IOrderItemRepository orderItemRepository, IIDeliverOrderInfoRepository iDeliverOrderInfoRepository, IConfigurationSettings configurationSettings, IWorkflowStorageFactory workflowStorageFactory)
        {
            this.orderItemRepository = orderItemRepository;
            this.iDeliverOrderInfoRepository = iDeliverOrderInfoRepository;
            this.configurationSettings = configurationSettings;
            this.workflowStorageFactory = workflowStorageFactory;
        }
        public async Task GetIDeliverSalesOrder()
        {
            int iDeliverOrderId = 0;
            var iDeliverProviders = configurationSettings.IDeliverProvider.Any() ? configurationSettings.IDeliverProvider.Split(',').Select(int.Parse).ToList() : new List<int>();
            if (!iDeliverProviders.Any())
            {
                return;
            }

            var skipOrderStatus = configurationSettings.SkipIDeliverOrderStatus.Any() ? configurationSettings.SkipIDeliverOrderStatus.Split(',').Select(int.Parse).ToList() : new List<int>();
            if (!skipOrderStatus.Any())
            {
                return;
            }

            //Get the order which are in Dispatch Ready/Dispatch Waiting state in chunks
            var orders = await iDeliverOrderInfoRepository.FindAllAsync(i => i.IDeliverOrderId > iDeliverOrderId && i.IDeliverOrderStatusId == 1, x => x.Take(50));
            if (orders == null || !orders.Any())
            {
                return;
            }
            else
            {
                while (orders.Any())
                {
                    var orderitms = new List<int> { 50251912 };
                    await PopulateSSQueue(60089159, orderitms);
                    foreach (var ideliverOrders in orders)
                    {
                        var ideliverOrderItems = await orderItemRepository.FindAllAsync(i => i.OrderId == ideliverOrders.OrderId && iDeliverProviders.Contains(i.OrderTypeId) && !skipOrderStatus.Contains(i.OrderStatusDetailId));
                        if (ideliverOrderItems == null || !ideliverOrderItems.Any())
                        {
                            continue;
                        }
                        //Get order Items counts which are in Dispatch:Ready status
                        var readyStatusOrderItemsCount = ideliverOrderItems.Where(x => x.OrderStatusDetailId == (int)OrderStatusDetail.DispatchReady).Count();

                        //Get order Items counts which are in Dispatch:Waiting status
                        var waitingStatusOrderItemsCount = ideliverOrderItems.Where(x => x.OrderStatusDetailId == (int)OrderStatusDetail.DispatchWaiting).Count();

                        //Make sure All Order Items are in Dispatch:ready Status or All are in Dispatch:waiting status then only allow to proceed for IDeliver
                        if ((readyStatusOrderItemsCount == ideliverOrderItems.Count) || (waitingStatusOrderItemsCount == ideliverOrderItems.Count))
                        {
                            await PopulateSSQueue(ideliverOrders.OrderId, ideliverOrderItems.Select(i => i.OrderItemId).ToList());
                        }

                    }
                    //Get the order which are in Dispatch Ready/Dispatch Waiting state in chunks
                    iDeliverOrderId = orders.Select(x => x.IDeliverOrderInfoId).LastOrDefault();
                    orders = await iDeliverOrderInfoRepository.FindAllAsync(i => i.IDeliverOrderId > iDeliverOrderId && i.IDeliverOrderStatusId == 1, x => x.Take(50));
                }
            }
        }
        public async Task PopulateSSQueue(int orderId, List<int> orderItemIds)
        {
            var request = new SSIDeliverOrderViewModel
            {
                OrderId = orderId,
                OrderItemIds = orderItemIds
            };
            await workflowStorageFactory.Create(configurationSettings.AzureStorageConnection, configurationSettings.SSIDeliverQueueName).AddItemToQueue(request);

        }
    }
}
