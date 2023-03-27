using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class OrderAnnotationConfiguration : IEntityTypeConfiguration<OrderAnnotation>
    {
        public void Configure(EntityTypeBuilder<OrderAnnotation> builder)
        {
            builder.ToTable("OrderAnnotation", "Ord");

            builder.HasKey(x => x.OrderAnnotationId);

            builder.Property(x => x.OrderItemId)
                .IsRequired();

            builder.Property(x => x.AnnotationDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Details)
                .IsRequired();

            builder.Property(x => x.AnnotationTypeId)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.Property(x => x.MSlogId);

            builder.Property(x => x.EMlogId);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.OrderItem)
                .WithMany()
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}