using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.HasKey(x => x.DealId);

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.Code)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Hot)
                .IsRequired();

            builder.Property(x => x.Available)
                .IsRequired();

            builder.Property(x => x.SupplierId);

            builder.Property(x => x.MsId);

            builder.Property(x => x.Emid);

            builder.Property(x => x.Gp)
                .IsRequired();

            builder.Property(x => x.Cost)
                .IsRequired();

            builder.Property(x => x.DealType)
                .IsRequired();

            builder.Property(x => x.ExternalReference)
                .IsRequired();

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate);

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Property(x => x.IsPublished)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.Multiple)
                .IsRequired();

            builder.Property(x => x.RatePlan)
                .IsRequired();

            builder.Property(x => x.MsdealId);

            builder.Property(x => x.EmdealId);

            builder.Property(x => x.SaleRuleId);

            builder.Property(x => x.ExpiryDate);

            builder.Property(x => x.IsInsurable);

            builder.Property(x => x.JbillingDealId);

            builder.Property(x => x.HandsetUid);

            builder.Property(x => x.CreditTabUid);

            builder.Property(x => x.IsBundle)
                .IsRequired();

            builder.Property(x => x.ThirdPartyCampaignId);

            builder.Property(x => x.IsFreemium);

            builder.Property(x => x.TrialPeriod);

            builder.Property(x => x.CancelIndividualOrder);

            builder.Property(x => x.RequiresUpfrontPayment);

            builder.Property(x => x.SimOnly);

            builder.Property(x => x.TariffId)
                .IsRequired();
        }
    }
}