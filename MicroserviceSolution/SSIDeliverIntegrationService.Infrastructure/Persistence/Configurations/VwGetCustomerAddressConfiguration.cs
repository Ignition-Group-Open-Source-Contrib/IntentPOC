using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations
{
    public class VwGetCustomerAddressConfiguration : IEntityTypeConfiguration<VwGetCustomerAddress>
    {
        public void Configure(EntityTypeBuilder<VwGetCustomerAddress> builder)
        {
            builder.ToView("vwGetCustomerAddress", "Cust").HasNoKey();

            builder.Property(x => x.CustomerAddressId)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.AddressTypeId)
                .IsRequired();

            builder.Property(x => x.ResIdenceTypeId);

            builder.Property(x => x.CityId)
                .IsRequired();

            builder.Property(x => x.CityName)
                .IsRequired();

            builder.Property(x => x.Company)
                .IsRequired();

            builder.Property(x => x.ProvinceId)
                .IsRequired();

            builder.Property(x => x.ProvinceName)
                .IsRequired();

            builder.Property(x => x.CountryName)
                .IsRequired();

            builder.Property(x => x.Notes)
                .IsRequired();

            builder.Property(x => x.DateAdded)
                .IsRequired();

            builder.Property(x => x.Suburb)
                .IsRequired();

            builder.Property(x => x.StreetName)
                .IsRequired();

            builder.Property(x => x.StreetNum)
                .IsRequired();

            builder.Property(x => x.Building)
                .IsRequired();

            builder.Property(x => x.PostCode)
                .IsRequired();

            builder.Property(x => x.DateAtAddress);

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate);

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Property(x => x.IsPublished)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.CustomerAddressOdooId);

            builder.Property(x => x.AddressCategoryId);

            builder.Property(x => x.DeliveredTo);

            builder.Property(x => x.LatLong)
                .IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }
    }
}