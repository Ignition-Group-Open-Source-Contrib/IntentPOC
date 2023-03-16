using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Cust;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Cust
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddresses", "Cust");

            builder.HasKey(x => x.CustomerAddressId);

            builder.Property(x => x.AddressTypeId)
                .IsRequired();

            builder.Property(x => x.ResIdenceTypeId);

            builder.Property(x => x.CityId)
                .IsRequired();

            builder.Property(x => x.Company)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.ProvinceId)
                .IsRequired();

            builder.Property(x => x.Notes)
                .HasColumnType("varchar(500)");

            builder.Property(x => x.DateAdded)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Suburb)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.StreetName)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.StreetNum)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Building)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.PostCode)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(x => x.DateAtAddress)
                .HasColumnType("datetime");

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

            builder.Property(x => x.MsCustomerAddressID);

            builder.Property(x => x.EMCustomerAddressID);

            builder.Property(x => x.CustomerAddressOdooId);

            builder.Property(x => x.Number)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.Department)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.FloorNo)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.NearByLandmark)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.DeliveredTo);

            builder.Property(x => x.LatLong)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerAddresses)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}