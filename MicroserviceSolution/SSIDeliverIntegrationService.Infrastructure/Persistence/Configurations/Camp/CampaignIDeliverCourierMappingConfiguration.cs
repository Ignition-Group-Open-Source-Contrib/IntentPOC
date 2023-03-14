using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Camp;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Camp
{
    public class CampaignIDeliverCourierMappingConfiguration : IEntityTypeConfiguration<CampaignIDeliverCourierMapping>
    {
        public void Configure(EntityTypeBuilder<CampaignIDeliverCourierMapping> builder)
        {
            builder.ToTable("CampaignIDeliverCourierMappings", "Camp");

            builder.HasKey(x => x.CampaignIDeliverCourierMappingID);

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}