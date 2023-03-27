using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class IDeliverOrderInfoConfiguration : IEntityTypeConfiguration<IDeliverOrderInfo>
    {
        public void Configure(EntityTypeBuilder<IDeliverOrderInfo> builder)
        {
            builder.ToTable("IDeliverOrderInfo", "Ord");

            builder.HasKey(x => x.IDeliverOrderInfoId);

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.IDeliverOrderId);

            builder.Property(x => x.IDeliverOrderStatusId);

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate)
                .HasDefaultValueSql("(getdate())");

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Property(x => x.CourierId)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}