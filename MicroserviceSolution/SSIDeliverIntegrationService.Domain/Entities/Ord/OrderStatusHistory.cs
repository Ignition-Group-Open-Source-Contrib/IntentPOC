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
    public class OrderStatusHistory : IHasDomainEvent
    {
        public int OrderStatusHistoryId { get; set; }

        public int OrderItemId { get; set; }

        public DateTime Occured { get; set; }

        public string Annotation { get; set; }

        public int? CancelStatusDetailId { get; set; }

        public int? EMOrderStatusHistoryId { get; set; }

        public int? MSOrderStatusHistoryId { get; set; }

        public int OrderStatusDetailId { get; set; }

        public int EmailCommSentStatusId { get; set; }

        public int SmscommSentStatusId { get; set; }

        public virtual OrderItem OrderItem { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}