using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessIDeliverOrderService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace ProcessIDeliverOrderService.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "Ord");
            builder.HasKey(x => x.OrderId);

            builder.Property(x => x.OrderDate)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.BrandId)
                .IsRequired();

            builder.Property(x => x.CampaignId)
                .IsRequired();

            builder.Property(x => x.DialerAgentId)
                .IsRequired();

            builder.Property(x => x.Period);

            builder.Property(x => x.Comments)
                .IsRequired();

            builder.Property(x => x.CallFlag)
                .IsRequired();

            builder.Property(x => x.BasketReference)
                .IsRequired();

            builder.Property(x => x.EscalationIndex)
                .IsRequired();

            builder.Property(x => x.DebitOrderDay);

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.LeadId);

            builder.Property(x => x.VerifierId)
                .IsRequired();

            builder.Property(x => x.EmailCommSentStatusId)
                .IsRequired();

            builder.Property(x => x.SmscommSentStatusId)
                .IsRequired();

            builder.Property(x => x.BillingIsPaid)
                .IsRequired();

            builder.Property(x => x.BillingDate);

            builder.Property(x => x.OverrideVettingUserId);

            builder.Property(x => x.VettingHistoryId);

            builder.Property(x => x.MsordermasterId);

            builder.Property(x => x.EmordermasterId);

            builder.Property(x => x.Affordability);

            builder.Property(x => x.CtFlag);

            builder.Property(x => x.OrderOdooId);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}