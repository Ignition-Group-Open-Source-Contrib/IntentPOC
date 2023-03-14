using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Deal;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Deal
{
    public class DealProductMappingConfiguration : IEntityTypeConfiguration<DealProductMapping>
    {
        public void Configure(EntityTypeBuilder<DealProductMapping> builder)
        {
            builder.ToTable("DealProductMappings", "Deal");

            builder.HasKey(x => x.DealProductMappingId);

            builder.Property(x => x.DealDealID);

            builder.Property(x => x.ProductId);

            builder.Property(x => x.Active)
                .HasDefaultValueSql("((1))");

            builder.Property(x => x.CreatedUserId);

            builder.Property(x => x.DbInsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.Property(x => x.ModifiedUserId);

            builder.Property(x => x.ModifiedDate)
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

            builder.HasOne(x => x.Deal)
                .WithMany()
                .HasForeignKey(x => x.DealDealID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}