using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using WebhookService.Application.Common.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventMessage", Version = "1.0")]

namespace WebhookService.Eventing
{
    public record IDeliverRTSCallBackEvent : IEvent
    {
        public const string PubsubName = "pubsub";
        public const string TopicName = nameof(IDeliverRTSCallBackEvent);
        public object Request { get; init; }
        string IEvent.PubsubName { get; } = PubsubName;
        string IEvent.TopicName { get; } = TopicName;
    }
}