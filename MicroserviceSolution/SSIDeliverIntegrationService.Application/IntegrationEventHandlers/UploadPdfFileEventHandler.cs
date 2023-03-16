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
    [IntentManaged(Mode.Fully, Body =  Mode.Merge)]
    public class UploadPdfFileEventHandler : IRequestHandler<UploadPdfFileEvent>
    {
        private readonly ISSIDeliverIntegrationFacade _sSIDeliverIntegrationFacade;

        [IntentManaged(Mode.Ignore)]
        public UploadPdfFileEventHandler(ISSIDeliverIntegrationFacade sSIDeliverIntegrationFacade)
        {
            _sSIDeliverIntegrationFacade = sSIDeliverIntegrationFacade;
            
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(UploadPdfFileEvent @event, CancellationToken cancellationToken)
        {
            await _sSIDeliverIntegrationFacade.UploadPdfFile(@event.SaleAgreementDetails);
            return Unit.Value;
        }
    }
}