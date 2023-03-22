using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem", "Ord", tb => tb.HasTrigger("trg_OrderItem_AfterUpdate"));

            builder.HasKey(x => x.OrderItemId);

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.DealId)
                .IsRequired();

            builder.Property(x => x.SMSSent)
                .IsRequired();

            builder.Property(x => x.FAXSent)
                .IsRequired();

            builder.Property(x => x.BuyOut)
                .IsRequired();

            builder.Property(x => x.SuspendCode)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.DeliveryInstruction)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.DocumentationCompleted)
                .IsRequired();

            builder.Property(x => x.RICAIndicator)
                .IsRequired();

            builder.Property(x => x.ItemEscalation)
                .IsRequired()
                .HasDefaultValueSql("((0.0))")
                .HasColumnType("varchar(16)");

            builder.Property(x => x.ThirdPartyReference)
                .HasColumnType("varchar(45)");

            builder.Property(x => x.OrderTypeId)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");

            builder.Property(x => x.OrderReference)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.OrderItemNumber)
                .IsRequired();

            builder.Property(x => x.CancelStatusDetailId);

            builder.Property(x => x.ProviderRef);

            builder.Property(x => x.VasRef);

            builder.Property(x => x.BankRef);

            builder.Property(x => x.BundleRef);

            builder.Property(x => x.RelatedOrderItemId);

            builder.Property(x => x.MSOrderId);

            builder.Property(x => x.EMOrderId);

            builder.Property(x => x.OperationDate)
                .HasColumnType("datetime");

            builder.Property(x => x.LastUpdatedByUserId);

            builder.Property(x => x.StatusChangeDate);

            builder.Property(x => x.TinyUrl)
                .HasColumnType("varchar(255)");

            builder.Property(x => x.IsMarketic)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.FreemiumOrderItemId);

            builder.Property(x => x.OrderStatusDetailId)
                .IsRequired();

            builder.HasOne(x => x.FreemiumOrderItem)
                .WithMany()
                .HasForeignKey(x => x.FreemiumOrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Deal)
                .WithMany()
                .HasForeignKey(x => x.DealId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}