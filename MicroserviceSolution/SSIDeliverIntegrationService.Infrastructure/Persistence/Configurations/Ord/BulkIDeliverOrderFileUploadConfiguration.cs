using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Persistence.Configurations.Ord
{
    public class BulkIDeliverOrderFileUploadConfiguration : IEntityTypeConfiguration<BulkIDeliverOrderFileUpload>
    {
        public void Configure(EntityTypeBuilder<BulkIDeliverOrderFileUpload> builder)
        {
            builder.ToTable("BulkIDeliverOrderFileUpload", "Ord");

            builder.HasKey(x => x.BulkIDeliverOrderFileUploadId);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(x => x.FileNameOnBlob)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(x => x.UploadedDate)
                .IsRequired();

            builder.Property(x => x.IsFileProcessed)
                .IsRequired()
                .HasDefaultValueSql("((0))");

            builder.Property(x => x.UpdatedOnDate);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}