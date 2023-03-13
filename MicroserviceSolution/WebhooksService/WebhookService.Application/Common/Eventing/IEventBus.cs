using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.Pubsub.EventBusInterface", Version = "1.0")]

namespace WebhookService.Application.Common.Eventing
{
    public interface IEventBus
    {

        void Publish<T>(T message)
            where T : IEvent;
        Task FlushAllAsync(CancellationToken cancellationToken = default);
    }
}