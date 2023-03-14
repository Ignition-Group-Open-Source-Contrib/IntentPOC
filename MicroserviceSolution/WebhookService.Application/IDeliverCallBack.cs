using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using WebhookService.Application.Common.Eventing;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.Event", Version = "1.0")]

namespace WebhookService.Application
{
    public class IDeliverCallBack : IEvent
    {
        public const string PubsubName = "pubsub";
        public const string TopicName = nameof(IDeliverCallBack);

        public object Request { get; set; }

        string IEvent.PubsubName => PubsubName;

        string IEvent.TopicName => TopicName;
    }
}