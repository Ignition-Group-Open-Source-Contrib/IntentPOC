using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SSIDeliverIntegrationService.Application.BackgroundWorker;
using SSIDeliverIntegrationService.Application.Common.BusinessLogic;
using SSIDeliverIntegrationService.Application.Common.Helper;
using SSIDeliverIntegrationService.Application.ViewModels;

[assembly: DefaultIntentManaged(Mode.Ignore)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace SSIDeliverIntegrationService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessSSIDeliverQueueController : ControllerBase
    {
        private readonly IBackgroundTaskQueue taskQueue;

        public ProcessSSIDeliverQueueController(IBackgroundTaskQueue taskQueue)
        {
            this.taskQueue = taskQueue;
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        [HttpPost("/processssideliverorderevent")]
        public async Task<ActionResult> ProcessSSIDeliverOrders([FromServices] IServiceScopeFactory serviceScopeFactory)
        {
            string encodedqueueMsg = string.Empty;
            string decodedQueueMsg = string.Empty;

            using (var reader = new StreamReader(Request.Body))
            {
                encodedqueueMsg = await reader.ReadToEndAsync();

                decodedQueueMsg = Base64Decode.Decode(encodedqueueMsg);
            }

            SSIDeliverOrderViewModel ssIDeliverOrderViewModel = JsonConvert.DeserializeObject<SSIDeliverOrderViewModel>(decodedQueueMsg);


            using var scope = serviceScopeFactory.CreateScope();
            var sSIDeliverIntegrationFacade = scope.ServiceProvider.GetRequiredService<ISSIDeliverIntegrationFacade>();
            await sSIDeliverIntegrationFacade.ProcessSSIDeliverOrders(ssIDeliverOrderViewModel);


            return Ok("Success");

        }
    }
}