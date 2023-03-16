using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderAnnotation : IHasDomainEvent
    {
        public int OrderAnnotationId { get; set; }

        public int OrderItemId { get; set; }

        public DateTime AnnotationDate { get; set; }

        public string Details { get; set; }

        public int AnnotationTypeId { get; set; }

        public int? MSlogId { get; set; }

        public int? EMlogId { get; set; }

        public int UserId { get; set; }

        public virtual OrderItem OrderItem { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}