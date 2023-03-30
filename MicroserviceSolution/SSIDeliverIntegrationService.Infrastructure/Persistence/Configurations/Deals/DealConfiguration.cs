using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Deals;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Deals
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.ToTable("Deal", "Deal");

            builder.HasKey(x => x.DealID);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Code)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Description);

            builder.Property(x => x.Hot)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.Available)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.Property(x => x.TariffID);

            builder.Property(x => x.MsId);

            builder.Property(x => x.EMId);

            builder.Property(x => x.GP)
                .IsRequired()
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");

            builder.Property(x => x.Cost)
                .IsRequired()
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");

            builder.Property(x => x.ExternalReference)
                .HasColumnType("varchar(250)");

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Property(x => x.IsPublished)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.Multiple)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.RatePlan)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.MSDealID);

            builder.Property(x => x.EMDealID);

            builder.Property(x => x.ExpiryDate);

            builder.Property(x => x.IsInsurable);

            builder.Property(x => x.JBillingDealId);

            builder.Property(x => x.HandsetUID);

            builder.Property(x => x.CreditTabUID);

            builder.Property(x => x.IsBundle)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.ThirdPartyCampaignId);

            builder.Property(x => x.IsFreemium)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.TrialPeriod);

            builder.Property(x => x.SysStartTime)
                .IsRequired()
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(x => x.SysEndTime)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([datetime2],'9999-12-31 23:59:59.9999999'))");

            builder.Property(x => x.CancelIndividualOrder)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.RequiresUpfrontPayment)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.SimOnly)
                .HasDefaultValueSql("((0))");

            builder.HasOne(x => x.Tariff)
                .WithMany()
                .HasForeignKey(x => x.TariffID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}