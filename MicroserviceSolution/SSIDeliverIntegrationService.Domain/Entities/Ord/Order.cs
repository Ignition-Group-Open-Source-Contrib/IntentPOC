using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;
using SSIDeliverIntegrationService.Domain.Entities.Cust;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class Order : IHasDomainEvent
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int DialerAgentId { get; set; }

        public int? Period { get; set; }

        public string? Comments { get; set; }

        public string CallFlag { get; set; }

        public string? BasketReference { get; set; }

        public int EscalationIndex { get; set; }

        public int? DebitOrderDay { get; set; }

        public int CustomerId { get; set; }

        public int? LeadId { get; set; }

        public bool? BillingIsPaid { get; set; }

        public DateTime? BillingDate { get; set; }

        public int? MSOrdermasterId { get; set; }

        public int? EMOrdermasterId { get; set; }

        public decimal? Affordability { get; set; }

        public bool? _ctFlag { get; set; }

        public int? OrderOdooId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}