using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Stock
{
    public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.ToTable("StockItems", "Stock");

            builder.HasKey(x => x.StockItemId);

            builder.Property(x => x.SerialNumber)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Pin)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(7, 2)");

            builder.Property(x => x.StockInvoiceId);

            builder.Property(x => x.ProductProductID)
                .IsRequired();

            builder.Property(x => x.ReturnStatus)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.SIM)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Received)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.StockStatusId);

            builder.Property(x => x.OrderItemOrderItemID);

            builder.Property(x => x.IMSI)
                .HasColumnType("varchar(20)");

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.MSStockItemId);

            builder.Property(x => x.EMStockItemId);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductProductID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OrderItem)
                .WithMany()
                .HasForeignKey(x => x.OrderItemOrderItemID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}