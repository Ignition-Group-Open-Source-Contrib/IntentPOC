using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Cust;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Cust
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Cust");

            builder.HasKey(x => x.CustomerID);

            builder.Property(x => x.IdNumber)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.OldMsId);

            builder.Property(x => x.OldEMId);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasColumnType("varchar(201)")
                .HasComputedColumnSql("(concat([FirstName],' ',[LastName]))");

            builder.Property(x => x.MaidenName)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Dependencies);

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

            builder.Property(x => x.MsCustomerID);

            builder.Property(x => x.EMCustomerID);

            builder.Property(x => x.IdentificationTypeId)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.Property(x => x._ctFlag);

            builder.Property(x => x.CustomerOdooId);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}