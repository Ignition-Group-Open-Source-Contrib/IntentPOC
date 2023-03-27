using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntegrationService.Application.Common.BusinessLogic;
using SSIDeliverIntegrationService.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.EventHandler", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IntegrationEventHandlers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PlaceSaleOnIDeliverEventHandler : IRequestHandler<PlaceSaleOnIDeliverEvent>
    {
        private readonly ISSIDeliverIntegrationFacade _iSSIDeliverIntegrationFacade;

        [IntentManaged(Mode.Ignore)]
        public PlaceSaleOnIDeliverEventHandler(ISSIDeliverIntegrationFacade iSSIDeliverIntegrationFacade)
        {
            _iSSIDeliverIntegrationFacade = iSSIDeliverIntegrationFacade;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(PlaceSaleOnIDeliverEvent @event, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}