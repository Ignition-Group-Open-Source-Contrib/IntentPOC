using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Camp;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Camp
{
    public class IDeliverCampaignChannelMappingConfiguration : IEntityTypeConfiguration<IDeliverCampaignChannelMapping>
    {
        public void Configure(EntityTypeBuilder<IDeliverCampaignChannelMapping> builder)
        {
            builder.ToTable("IDeliverCampaignChannelMapping", "Camp");

            builder.HasKey(x => x.IDeliverCampaignChannelMappingId);

            builder.Property(x => x.ChannelId)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .IsRequired();

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}