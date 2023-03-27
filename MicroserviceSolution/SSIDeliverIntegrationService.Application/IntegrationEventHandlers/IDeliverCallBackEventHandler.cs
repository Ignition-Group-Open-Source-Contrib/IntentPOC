using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Newtonsoft.Json;
using SSIDeliverIntegrationService.Application.Common.BusinessLogic;
using SSIDeliverIntegrationService.Application.ViewModels;
using WebhookService.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.EventHandler", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IntegrationEventHandlers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class IDeliverCallBackEventHandler : IRequestHandler<IDeliverCallBackEvent>
    {
        private readonly ISSIDeliverIntegrationFacade sSIDeliverIntegrationFacade;

        [IntentManaged(Mode.Ignore)]
        public IDeliverCallBackEventHandler(ISSIDeliverIntegrationFacade sSIDeliverIntegrationFacade)
        {

            this.sSIDeliverIntegrationFacade = sSIDeliverIntegrationFacade;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(IDeliverCallBackEvent @event, CancellationToken cancellationToken)
        {
            var request = JsonConvert.DeserializeObject<IDeliverOrderCallBackAPIRequest>(@event.Request.ToString());
            await sSIDeliverIntegrationFacade.ProcessStockOrder(request, cancellationToken);
            return Unit.Value;
        }
    }
}