using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessIDeliverOrderService.Application.BackgroundWorker
{
    public class ProcessIDeliverOrder : BackgroundService
    {
        public IServiceProvider Services { get; }
        public ProcessIDeliverOrder(IServiceProvider services) 
        {
            this.Services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                    using (var scope = Services.CreateScope())
                    {
                        var scopedProcessingService = scope.ServiceProvider.GetRequiredService<Common.BusinessLogic.ISSIDeliverIntegrationFacade>();
                        // check Orders ready to place sale on IDeliver
                        await scopedProcessingService.GetIDeliverSalesOrder();
                    }               
               
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
