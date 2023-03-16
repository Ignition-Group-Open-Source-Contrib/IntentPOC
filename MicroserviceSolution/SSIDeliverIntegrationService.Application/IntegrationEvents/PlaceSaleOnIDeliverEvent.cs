using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Application.Common.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace SSIDeliverIntegrationService.Eventing
{
    public record PlaceSaleOnIDeliverEvent : IEvent
    {
        public const string PubsubName = "pubsub";
        public const string TopicName = nameof(PlaceSaleOnIDeliverEvent);
        public int OrderId { get; init; }
        public IEnumerable<int> OrderItems { get; init; }
        string IEvent.PubsubName { get; } = PubsubName;
        string IEvent.TopicName { get; } = TopicName;
    }
}