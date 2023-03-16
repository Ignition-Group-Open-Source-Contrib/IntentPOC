using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Deals;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Deals
{
    public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.ToTable("Tariffs", "Deal");

            builder.HasKey(x => x.TariffID);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(x => x.Duration)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            builder.Property(x => x.PayIn)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");

            builder.Property(x => x.MonthsFree)
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.Active)
                .HasDefaultValueSql("((1))");

            builder.Property(x => x.Picture)
                .HasColumnType("varbinary(max)");

            builder.Property(x => x.TopBillingProductName)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Limit)
                .HasColumnType("decimal(18, 2)");

            builder.Property(x => x.MsTariffId);

            builder.Property(x => x.RatePlan)
                .HasColumnType("varchar(100)");

            builder.Property(x => x.ExternalReference)
                .HasColumnType("varchar(250)");

            builder.Property(x => x.SysStartTime)
                .IsRequired()
                .HasDefaultValueSql("(getutcdate())");

            builder.Property(x => x.SysEndTime)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([datetime2],'9999-12-31 23:59:59.9999999'))");

            builder.HasIndex(x => x.TariffID)
                .IsUnique()
                .HasDatabaseName("IX_TariffID");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}