using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.OrderItemId);

            builder.Property(x => x.DocumentId);

            builder.Property(x => x.Smssent)
                .IsRequired();

            builder.Property(x => x.Faxsent)
                .IsRequired();

            builder.Property(x => x.BuyOut)
                .IsRequired();

            builder.Property(x => x.SuspendCode)
                .IsRequired();

            builder.Property(x => x.DeliveryInstruction)
                .IsRequired();

            builder.Property(x => x.DocumentationCompleted)
                .IsRequired();

            builder.Property(x => x.Ricaindicator)
                .IsRequired();

            builder.Property(x => x.ItemEscalation)
                .IsRequired();

            builder.Property(x => x.ThirdPartyReference)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.OrderReference)
                .IsRequired();

            builder.Property(x => x.OrderItemNumber)
                .IsRequired();

            builder.Property(x => x.CustomerBankId);

            builder.Property(x => x.OrderStatusDetailId)
                .IsRequired();

            builder.Property(x => x.OrderCancelReasonDetailId);

            builder.Property(x => x.OrderTypeId)
                .IsRequired();

            builder.Property(x => x.CancelStatusDetailId);

            builder.Property(x => x.ProviderRef);

            builder.Property(x => x.VasRef);

            builder.Property(x => x.BankRef);

            builder.Property(x => x.BundleId);

            builder.Property(x => x.BundleRef);

            builder.Property(x => x.PayMethodId)
                .IsRequired();

            builder.Property(x => x.FaisUserId);

            builder.Property(x => x.RelatedOrderItemId);

            builder.Property(x => x.MsorderId);

            builder.Property(x => x.EmorderId);

            builder.Property(x => x.OperationDate);

            builder.Property(x => x.LastUpdatedByUserId);

            builder.Property(x => x.StatusChangeDate);

            builder.Property(x => x.TinyUrl)
                .IsRequired();

            builder.Property(x => x.FreemiumOrderItemId);

            builder.Property(x => x.IsMarketic);

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.DealDealId)
                .IsRequired();

            builder.OwnsMany(x => x.OrderStatusHistories, ConfigureOrderStatusHistories);

            builder.HasOne(x => x.Deal)
                .WithMany()
                .HasForeignKey(x => x.DealDealId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public void ConfigureOrderStatusHistories(OwnedNavigationBuilder<OrderItem, OrderStatusHistory> builder)
        {
            builder.WithOwner()
                .HasForeignKey(x => x.OrderItemId);

            builder.HasKey(x => x.OrderStatusHistoryId);

            builder.Property(x => x.Occured)
                .IsRequired();

            builder.Property(x => x.Annotation)
                .IsRequired();

            builder.Property(x => x.OrderStatusDetailId)
                .IsRequired();

            builder.Property(x => x.OrderCancelReasonDetailId);

            builder.Property(x => x.CancelStatusDetailId);

            builder.Property(x => x.EmailCommSentStatusId)
                .IsRequired();

            builder.Property(x => x.SmscommSentStatusId)
                .IsRequired();

            builder.Property(x => x.UserId);

            builder.Property(x => x.EmorderStatusHistoryId);

            builder.Property(x => x.MsorderStatusHistoryId);

            builder.Property(x => x.OrderItemId)
                .IsRequired();
        }
    }
}