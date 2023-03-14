using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class OrderDeliveryConfiguration : IEntityTypeConfiguration<OrderDelivery>
    {
        public void Configure(EntityTypeBuilder<OrderDelivery> builder)
        {
            builder.ToTable("OrderDeliveries", "Ord");

            builder.HasKey(x => x.OrderDeliveryId);

            builder.Property(x => x.OrderItemOrderItemID)
                .IsRequired();

            builder.Property(x => x.CustomerAddressCustomerAddressID)
                .IsRequired();

            builder.Property(x => x.DeliveryTypeDeliveryTypeID);

            builder.Property(x => x.DispatchWayBillNumber);

            builder.Property(x => x.DispatchDate)
                .HasColumnType("datetime");

            builder.Property(x => x.WayBillNumber)
                .HasColumnType("nvarchar(30)");

            builder.Property(x => x.FastTrackerNumber);

            builder.Property(x => x.EstimateDeliveryDate)
                .HasColumnType("datetime");

            builder.Property(x => x.DeliveryDate)
                .HasColumnType("datetime");

            builder.Property(x => x.Directions)
                .HasColumnType("varchar(500)");

            builder.Property(x => x.IMEI)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.OrderNumber)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.DeliveryNote)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.PackageStatus)
                .HasColumnType("varchar(10)");

            builder.Property(x => x.ReleaseForDespatch)
                .HasColumnType("varchar(1)");

            builder.Property(x => x.PaymentRef)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.ConsignedFlag)
                .HasColumnType("varchar(1)");

            builder.Property(x => x.RTS)
                .HasColumnType("varchar(1)");

            builder.Property(x => x.RTSReason)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.RTSNote)
                .HasColumnType("varchar(500)");

            builder.Property(x => x.ConsignmentID)
                .HasColumnType("varchar(50)");

            builder.HasOne(x => x.CustomerAddress)
                .WithMany()
                .HasForeignKey(x => x.CustomerAddressCustomerAddressID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OrderItem)
                .WithMany()
                .HasForeignKey(x => x.OrderItemOrderItemID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DeliveryType)
                .WithMany()
                .HasForeignKey(x => x.DeliveryTypeDeliveryTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.OrderDeliveryId)
                .IsUnique()
                .HasDatabaseName("IX_OrderDeliveryId");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}