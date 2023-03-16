using IgnitionGroup.AzureStorageQueueHelper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSIDeliverIntegrationService.Application.Common.BusinessLogic;
using SSIDeliverIntegrationService.Application.Common.Configuration;
using SSIDeliverIntegrationService.Application.Common.Eventing;
using SSIDeliverIntegrationService.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSIDeliverIntegrationService.Application.BackgroundWorker
{
    public class ProcessSSIDeliverQueue : BackgroundService
    {
        private readonly IWorkflowStorageFactory workflowStorageFactory;
        private readonly IConfigurationSettings configuration;
        private readonly IEventBus eventBus;

        public IServiceProvider Services { get; }

        public ProcessSSIDeliverQueue(IWorkflowStorageFactory workflowStorageFactory, IServiceProvider services, IConfigurationSettings configuration,IEventBus eventBus)
        {
            this.workflowStorageFactory = workflowStorageFactory;
            this.configuration = configuration;
            this.eventBus = eventBus;
            this.Services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connectiontoStorage = configuration.AzureStorageConnection;
            var queueName = configuration.SSIDeliverQueueName;
            var queueStorage = workflowStorageFactory.Create(connectiontoStorage, queueName);
            //Get the IDeliver Provider Ids from app configuration
            var iDeliverProviders = configuration.IDeliverProvider.Any() ? configuration.IDeliverProvider.Split(',').Select(int.Parse).ToList() : new List<int>();
            if (!iDeliverProviders.Any())
            {
                return;
            }

            //Get the skip order status ids from app configuration
            var skipOrderStatus = configuration.SkipIDeliverOrderStatus.Any() ? configuration.SkipIDeliverOrderStatus.Split(',').Select(int.Parse).ToList() : new List<int>();
            if (!skipOrderStatus.Any())
            {
                return;
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                int orderId = 0;
                var queueMessage = await queueStorage.GetItemFromQueue();
                if (queueMessage == null)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(configuration.ProcessSSIDeliverQueueDelayMilliSeconds), stoppingToken);
                    continue;
                }

                try
                {
                    //Validate order id value
                    int.TryParse(queueMessage.AsString, out orderId);
                    if (!int.TryParse(queueMessage.AsString, out orderId))
                    {
                        await queueStorage.DeleteItemFromQueue(queueMessage);
                        continue;
                    }


                    using (var scope = Services.CreateScope())
                    {
                        var scopedProcessingService = scope.ServiceProvider.GetRequiredService<ISSIDeliverIntegrationFacade>();

                        //Verify the invalid orders and remove that from ssideliver queue
                        var inValidOrder = await scopedProcessingService.VerifyInValidOrder(orderId, iDeliverProviders);

                        //Verify is IDeliver Order or not.
                        var isIDeliverOrder = await scopedProcessingService.VerifyIDeliverOrder(orderId, iDeliverProviders);

                        if (inValidOrder && !isIDeliverOrder)
                        {
                            await queueStorage.DeleteItemFromQueue(queueMessage);
                            continue;
                        }

                        //Verify the skip status orders and remove that from ssideliver queue
                        var inValidOrderStatus = await scopedProcessingService.VerifyInValidOrderStatus(orderId, iDeliverProviders, skipOrderStatus);
                        if (inValidOrderStatus && !isIDeliverOrder)
                        {
                            await queueStorage.DeleteItemFromQueue(queueMessage);
                            continue;
                        }

                        //Get the order items which requires to be placed on Ideliver
                        var orderItems = await scopedProcessingService.GetIDeliverOrderItems(orderId, iDeliverProviders, skipOrderStatus);
                        if (orderItems == null || !orderItems.Any())
                        {
                            continue;
                        }

                       // var daprApi = scope.ServiceProvider.GetRequiredService<IDaprApi>();
                        //Place sale on Ideliver
                        
                       // var response = await daprApi.PlaceSaleOnIDeliver(orderId, orderItems);
                       eventBus.Publish(new PlaceSaleOnIDeliverEvent { OrderId = orderId, OrderItems = orderItems});
                        await queueStorage.DeleteItemFromQueue(queueMessage);
                    }
                }
                catch (Exception ex)
                {
                    await queueStorage.DeleteItemFromQueue(queueMessage);
                }

            }
        }
    }
}
