using System;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntegrationService.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.EventHandler", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IntegrationEventHandlers
{
    [IntentManaged(Mode.Merge, Body = Mode.Fully)]
    public class PlaceSaleOnIDeliverEventHandler : IRequestHandler<PlaceSaleOnIDeliverEvent>
    {
        [IntentManaged(Mode.Ignore)]
        public PlaceSaleOnIDeliverEventHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(PlaceSaleOnIDeliverEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}