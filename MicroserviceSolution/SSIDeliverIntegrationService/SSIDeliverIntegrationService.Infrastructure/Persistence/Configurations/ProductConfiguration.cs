using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.WriteUp)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();

            builder.Property(x => x.StockCount);

            builder.Property(x => x.Barcode)
                .IsRequired();

            builder.Property(x => x.ManufacturerId)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.OldProdId);

            builder.Property(x => x.ProductOdooId);

            builder.OwnsMany(x => x.ProductDimensions, ConfigureProductDimensions);

            builder.HasMany(x => x.StockItems)
                .WithOne()
                .HasForeignKey(x => x.ProductId);

            builder.OwnsMany(x => x.IdeliverProductChannelMappings, ConfigureIdeliverProductChannelMappings);

            builder.Ignore(e => e.DomainEvents);
        }

        public void ConfigureProductDimensions(OwnedNavigationBuilder<Product, ProductDimensions> builder)
        {
            builder.WithOwner()
                .HasForeignKey(x => x.ProductId);

            builder.HasKey(x => x.ProductDimensionsId);

            builder.Property(x => x.Weight);

            builder.Property(x => x.Height);

            builder.Property(x => x.Breadth);

            builder.Property(x => x.Length);

            builder.Property(x => x.ProductId)
                .IsRequired();
        }

        public void ConfigureIdeliverProductChannelMappings(OwnedNavigationBuilder<Product, IdeliverProductChannelMapping> builder)
        {
            builder.WithOwner()
                .HasForeignKey(x => x.ProductId);

            builder.HasKey(x => x.IdeliverProductChannelMappingId);

            builder.Property(x => x.ChannelId)
                .IsRequired();

            builder.Property(x => x.IdeliverProductId);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate);

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Property(x => x.ProductId)
                .IsRequired();
        }
    }
}