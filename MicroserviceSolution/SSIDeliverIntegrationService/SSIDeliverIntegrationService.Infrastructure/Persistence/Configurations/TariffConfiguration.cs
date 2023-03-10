using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations
{
    public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.HasKey(x => x.TariffId);

            builder.Property(x => x.ProvIderId)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Duration);

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.PayIn);

            builder.Property(x => x.MonthsFree);

            builder.Property(x => x.Active);

            builder.Property(x => x.Picture)
                .IsRequired();

            builder.Property(x => x.TopBilingProductName)
                .IsRequired();

            builder.Property(x => x.TopBillingLookupId);

            builder.Property(x => x.Limit);

            builder.Property(x => x.MsTariffId);

            builder.Property(x => x.RatePlan)
                .IsRequired();

            builder.Property(x => x.ExternalReference)
                .IsRequired();

            builder.HasMany(x => x.Deals)
                .WithOne()
                .HasForeignKey(x => x.TariffId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}