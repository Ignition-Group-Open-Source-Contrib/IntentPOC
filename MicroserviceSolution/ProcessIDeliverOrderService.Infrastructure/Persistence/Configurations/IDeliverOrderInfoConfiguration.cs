using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessIDeliverOrderService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace ProcessIDeliverOrderService.Infrastructure.Persistence.Configurations
{
    public class IDeliverOrderInfoConfiguration : IEntityTypeConfiguration<IDeliverOrderInfo>
    {
        public void Configure(EntityTypeBuilder<IDeliverOrderInfo> builder)
        {
            builder.ToTable("IDeliverOrderInfo", "Ord");
            builder.HasKey(x => x.IDeliverOrderInfoId);

            builder.Property(x => x.IDeliverOrderId);

            builder.Property(x => x.IDeliverOrderStatusId);

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate);

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Property(x => x.CourierId)
                .IsRequired();

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithMany(x => x.IDeliverOrderInfos)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}