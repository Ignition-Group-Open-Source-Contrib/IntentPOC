using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Admin;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Admin
{
    public class DeliveryTypeConfiguration : IEntityTypeConfiguration<DeliveryType>
    {
        public void Configure(EntityTypeBuilder<DeliveryType> builder)
        {
            builder.ToTable("DeliveryType", "Admin");

            builder.HasKey(x => x.DeliveryTypeId);

            builder.Property(x => x.DeliveryTypeValue)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("DeliveryType");

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.IsPublished)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.HasIndex(x => x.DeliveryTypeId)
                .IsUnique()
                .HasDatabaseName("IX_DeliveryTypeID");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}