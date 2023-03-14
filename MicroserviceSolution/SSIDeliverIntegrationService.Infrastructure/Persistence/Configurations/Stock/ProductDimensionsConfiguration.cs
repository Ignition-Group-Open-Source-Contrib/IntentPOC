using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Stock
{
    public class ProductDimensionsConfiguration : IEntityTypeConfiguration<ProductDimensions>
    {
        public void Configure(EntityTypeBuilder<ProductDimensions> builder)
        {
            builder.ToTable("ProductDimensions", "Stock");

            builder.HasKey(x => x.ProductDimensionsId);

            builder.Property(x => x.ProductID)
                .IsRequired();

            builder.Property(x => x.Weight)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 4)");

            builder.Property(x => x.Height)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 4)");

            builder.Property(x => x.Breadth)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 4)");

            builder.Property(x => x.Length)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 4)");

            builder.HasIndex(x => x.ProductDimensionsId)
                .IsUnique()
                .HasDatabaseName("IX_ProductDimensionsId");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}