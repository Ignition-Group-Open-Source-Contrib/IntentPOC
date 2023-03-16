using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Admin;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Admin
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province", "Admin");

            builder.HasKey(x => x.ProvinceID);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)");

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

            builder.HasIndex(x => x.ProvinceID)
                .IsUnique()
                .HasDatabaseName("IX_ProvinceID");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}