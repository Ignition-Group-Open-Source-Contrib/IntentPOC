using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Application.Common.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace SSIDeliverIntegrationService.Eventing
{
    public record UploadPdfFileEvent : IEvent
    {
        public const string PubsubName = "pubsub";
        public const string TopicName = nameof(UploadPdfFileEvent);
        public UploadPdfViewModel SaleAgreementDetails { get; init; }
        string IEvent.PubsubName { get; } = PubsubName;
        string IEvent.TopicName { get; } = TopicName;
    }
}