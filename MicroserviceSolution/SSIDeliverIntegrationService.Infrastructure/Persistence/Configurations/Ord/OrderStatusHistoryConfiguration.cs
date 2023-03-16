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
            builder.ToTable("OrderStatusHistory", "Ord");

            builder.HasKey(x => x.OrderStatusHistoryId);

            builder.Property(x => x.OrderItemId)
                .IsRequired();

            builder.Property(x => x.Occured)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Annotation)
                .IsRequired();

            builder.Property(x => x.CancelStatusDetailId);

            builder.Property(x => x.EMOrderStatusHistoryId);

            builder.Property(x => x.MSOrderStatusHistoryId);

            builder.Property(x => x.OrderStatusDetailId)
                .IsRequired();

            builder.Property(x => x.EmailCommSentStatusId)
                .IsRequired();

            builder.Property(x => x.SmscommSentStatusId)
                .IsRequired();

            builder.HasOne(x => x.OrderItem)
                .WithMany(x => x.OrderStatusHistories)
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}