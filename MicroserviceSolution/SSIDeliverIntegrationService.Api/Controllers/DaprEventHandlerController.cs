using System.Threading;
using System.Threading.Tasks;
using Dapr;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSIDeliverIntegrationService.Eventing;
using WebhookService.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.DaprEventHandlerController", Version = "1.0")]

namespace SSIDeliverIntegrationService.Api.Controllers
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class DaprEventHandlerController : ControllerBase
    {
        private readonly ISender _mediatr;

        public DaprEventHandlerController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [Topic(IDeliverCallBackEvent.PubsubName, IDeliverCallBackEvent.TopicName)]
        public async Task HandleIDeliverCallBackEvent(IDeliverCallBackEvent @event, CancellationToken cancellationToken)
        {
            await _mediatr.Send(@event, cancellationToken);
        }

        [HttpPost]
        [Topic(UploadPdfFileEvent.PubsubName, UploadPdfFileEvent.TopicName)]
        public async Task HandleUploadPdfFileEvent(UploadPdfFileEvent @event, CancellationToken cancellationToken)
        {
            await _mediatr.Send(@event, cancellationToken);
        }

        [HttpPost]
        [Topic(PlaceSaleOnIDeliverEvent.PubsubName, PlaceSaleOnIDeliverEvent.TopicName)]
        public async Task HandlePlaceSaleOnIDeliverEvent(PlaceSaleOnIDeliverEvent @event, CancellationToken cancellationToken)
        {
            await _mediatr.Send(@event, cancellationToken);
        }

    }
}