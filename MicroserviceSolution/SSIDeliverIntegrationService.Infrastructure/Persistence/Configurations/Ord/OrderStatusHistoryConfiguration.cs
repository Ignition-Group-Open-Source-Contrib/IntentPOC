using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
    {
        public void Configure(EntityTypeBuilder<OrderStatusHistory> builder)
        {
            builder.ToTable("OrderStatusHistories", "Ord");

            builder.HasKey(x => x.OrderStatusHistoryId);

            builder.Property(x => x.OrderItemOrderItemID)
                .IsRequired();

            builder.Property(x => x.Occured)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Annotation)
                .IsRequired();

            builder.Property(x => x.CancelStatusDetailId);

            builder.Property(x => x.EMOrderStatusHistoryId);

            builder.Property(x => x.MSOrderStatusHistoryId);

            builder.HasOne(x => x.OrderItem)
                .WithMany()
                .HasForeignKey(x => x.OrderItemOrderItemID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}