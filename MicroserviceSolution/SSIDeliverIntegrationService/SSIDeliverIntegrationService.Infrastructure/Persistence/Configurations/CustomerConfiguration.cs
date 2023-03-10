using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.Property(x => x.IdNumber)
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .IsRequired();

            builder.Property(x => x.LastName)
                .IsRequired();

            builder.Property(x => x.TitleId)
                .IsRequired();

            builder.Property(x => x.MaritalStatusId);

            builder.Property(x => x.OldMsId);

            builder.Property(x => x.OldEmid);

            builder.Property(x => x.FullName)
                .IsRequired();

            builder.Property(x => x.MaidenName)
                .IsRequired();

            builder.Property(x => x.Dependencies);

            builder.Property(x => x.Education);

            builder.Property(x => x.CreatedByUserId);

            builder.Property(x => x.CreatedOnDate);

            builder.Property(x => x.UpdatedByUserId);

            builder.Property(x => x.UpdatedOnDate);

            builder.Property(x => x.IsPublished)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.MsCustomerId);

            builder.Property(x => x.EmcustomerId);

            builder.Property(x => x.IdentificationTypeId)
                .IsRequired();

            builder.Property(x => x.CustomerOdooId);

            builder.Property(x => x.CtFlag);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}