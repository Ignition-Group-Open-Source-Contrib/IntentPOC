using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.EventInterface", Version = "1.0")]

namespace WebhookService.Application.Common.Eventing
{
    public interface IEvent : IRequest
    {

        string PubsubName { get; }
        string TopicName { get; }
    }
}