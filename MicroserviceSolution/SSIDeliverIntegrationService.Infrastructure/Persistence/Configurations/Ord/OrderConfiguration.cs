using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Ord");

            builder.HasKey(x => x.OrderId);

            builder.Property(x => x.OrderDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.DialerAgentId)
                .IsRequired();

            builder.Property(x => x.Period);

            builder.Property(x => x.Comments)
                .HasColumnType("varchar(500)");

            builder.Property(x => x.CallFlag)
                .IsRequired()
                .HasColumnType("varchar(1)");

            builder.Property(x => x.BasketReference)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.EscalationIndex)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.DebitOrderDay);

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.LeadId);

            builder.Property(x => x.BillingIsPaid)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.BillingDate)
                .HasColumnType("datetime");

            builder.Property(x => x.MSOrdermasterId);

            builder.Property(x => x.EMOrdermasterId);

            builder.Property(x => x.Affordability)
                .HasColumnType("decimal(18, 4)");

            builder.Property(x => x._ctFlag);

            builder.Property(x => x.OrderOdooId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}