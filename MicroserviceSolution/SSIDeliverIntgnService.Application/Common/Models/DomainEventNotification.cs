using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MediatR.DomainEvents.DomainEventNotification", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Common.Models
{
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }

        public TDomainEvent DomainEvent { get; }
    }
}