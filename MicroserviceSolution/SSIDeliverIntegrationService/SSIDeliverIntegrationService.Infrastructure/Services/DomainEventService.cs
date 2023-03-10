using System;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.Extensions.Logging;
using SSIDeliverIntegrationService.Application.Common.Interfaces;
using SSIDeliverIntegrationService.Application.Common.Models;
using SSIDeliverIntegrationService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Ignore)]
[assembly: IntentTemplate("Intent.MediatR.DomainEvents.DomainEventService", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger<DomainEventService> _logger;
        private readonly IPublisher _mediator;

        public DomainEventService(ILogger<DomainEventService> logger, IPublisher mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
            await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
}