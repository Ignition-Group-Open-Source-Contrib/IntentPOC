using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations
{
    public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.HasKey(x => x.StockItemId);

            builder.Property(x => x.SerialNumber)
                .IsRequired();

            builder.Property(x => x.Pin)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.StockPurchaseOrderId);

            builder.Property(x => x.StockInvoiceId);

            builder.Property(x => x.ReturnStatus);

            builder.Property(x => x.BrandId);

            builder.Property(x => x.Sim)
                .IsRequired();

            builder.Property(x => x.Received);

            builder.Property(x => x.StockStatusId);

            builder.Property(x => x.Imsi)
                .IsRequired();

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.MsstockItemId);

            builder.Property(x => x.EmstockItemId);

            builder.Property(x => x.ItemStatus);

            builder.Property(x => x.StockReturnState);

            builder.Property(x => x.ProductId);

            builder.HasMany(x => x.OrderItems)
                .WithMany("StockItems")
                .UsingEntity(x => x.ToTable("StockItemOrderItems"));

            builder.Ignore(e => e.DomainEvents);
        }
    }
}