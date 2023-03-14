using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Stock
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class StockItem : IHasDomainEvent
    {
        public int StockItemId { get; set; }

        public string? SerialNumber { get; set; }

        public string? Pin { get; set; }

        public decimal Price { get; set; }

        public int? StockInvoiceId { get; set; }

        public int ProductProductID { get; set; }

        public int? ReturnStatus { get; set; }

        public string? SIM { get; set; }

        public int? Received { get; set; }

        public int? StockStatusId { get; set; }

        public int? OrderItemOrderItemID { get; set; }

        public string? IMSI { get; set; }

        public int? CreatedByUserId { get; set; }

        public int? MSStockItemId { get; set; }

        public int? EMStockItemId { get; set; }

        public virtual Product Product { get; set; }

        public virtual OrderItem? OrderItem { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}