using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class VASXProviderSpecificConfiguration : IEntityTypeConfiguration<VASXProviderSpecific>
    {
        public void Configure(EntityTypeBuilder<VASXProviderSpecific> builder)
        {
            builder.ToTable("VASXProviderSpecifics", "Ord");

            builder.HasKey(x => x.VASXProviderSpecificId);

            builder.Property(x => x.OrderItemId)
                .IsRequired();

            builder.Property(x => x.Iccid)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.SubscriberUid)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.IMSI)
                .HasColumnType("varchar(30)");

            builder.HasOne(x => x.OrderItem)
                .WithMany()
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.VASXProviderSpecificId)
                .IsUnique()
                .HasDatabaseName("IX_VASXProviderSpecificId");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}