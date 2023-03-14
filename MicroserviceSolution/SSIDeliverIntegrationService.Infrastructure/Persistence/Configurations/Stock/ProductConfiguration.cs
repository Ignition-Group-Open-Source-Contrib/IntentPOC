using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Stock
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Stock");

            builder.HasKey(x => x.ProductID);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Description)
                .HasColumnType("varchar(2000)");

            builder.Property(x => x.WriteUp)
                .HasColumnType("varchar(2000)");

            builder.Property(x => x.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.Property(x => x.StockCount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric");

            builder.Property(x => x.Barcode)
                .HasDefaultValueSql("(newid())")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired()
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");

            builder.Property(x => x.OldProdId);

            builder.Property(x => x.ProductOdooId);

            builder.Property(x => x.SysStartTime)
                .IsRequired()
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(x => x.SysEndTime)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([datetime2],'9999-12-31 23:59:59.9999999'))");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}