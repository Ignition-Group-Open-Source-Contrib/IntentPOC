using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Stock
{
    public class IDeliverProductChannelMappingConfiguration : IEntityTypeConfiguration<IDeliverProductChannelMapping>
    {
        public void Configure(EntityTypeBuilder<IDeliverProductChannelMapping> builder)
        {
            builder.ToTable("IDeliverProductChannelMappings", "Stock");

            builder.HasKey(x => x.IDeliverProductChannelMappingId);

            builder.Property(x => x.ProductId)
                .IsRequired();

            builder.Property(x => x.ChannelId)
                .IsRequired();

            builder.Property(x => x.IDeliverProductId);

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.IDeliverProductChannelMappings)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}