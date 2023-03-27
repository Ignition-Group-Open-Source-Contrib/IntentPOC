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
    public class IDeliverOrderInfo : IHasDomainEvent
    {
        public int IDeliverOrderInfoId { get; set; }

        public int OrderId { get; set; }

        public int? IDeliverOrderId { get; set; }

        public int? IDeliverOrderStatusId { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public int CourierId { get; set; }

        public virtual Order Order { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}