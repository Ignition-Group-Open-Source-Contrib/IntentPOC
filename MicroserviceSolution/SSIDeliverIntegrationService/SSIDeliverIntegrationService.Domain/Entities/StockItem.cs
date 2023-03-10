using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class StockItem : IHasDomainEvent
    {
        public int StockItemId { get; set; }

        public string SerialNumber { get; set; }

        public string Pin { get; set; }

        public string Price { get; set; }

        public int? StockPurchaseOrderId { get; set; }

        public int? StockInvoiceId { get; set; }

        public int? ReturnStatus { get; set; }

        public int? BrandId { get; set; }

        public string Sim { get; set; }

        public int? Received { get; set; }

        public int? StockStatusId { get; set; }

        public string Imsi { get; set; }

        public int? CreatedByUserId { get; set; }

        public int? MsstockItemId { get; set; }

        public int? EmstockItemId { get; set; }

        public int? ItemStatus { get; set; }

        public int? StockReturnState { get; set; }

        public int? ProductId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}