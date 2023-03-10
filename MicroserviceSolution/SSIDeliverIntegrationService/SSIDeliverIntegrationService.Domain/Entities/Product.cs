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
    public class Product : IHasDomainEvent
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string WriteUp { get; set; }

        public int Active { get; set; }

        public decimal? StockCount { get; set; }

        public int Barcode { get; set; }

        public int ManufacturerId { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int? OldProdId { get; set; }

        public int? ProductOdooId { get; set; }

        public virtual ICollection<ProductDimensions> ProductDimensions { get; set; } = new List<ProductDimensions>();

        public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();

        public virtual ICollection<IdeliverProductChannelMapping> IdeliverProductChannelMappings { get; set; } = new List<IdeliverProductChannelMapping>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}