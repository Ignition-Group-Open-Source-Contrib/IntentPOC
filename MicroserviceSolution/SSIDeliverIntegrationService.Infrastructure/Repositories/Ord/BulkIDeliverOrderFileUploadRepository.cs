using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Ord;
using SSIDeliverIntegrationService.Domain.Repositories.Ord;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Ord
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class BulkIDeliverOrderFileUploadRepository : RepositoryBase<BulkIDeliverOrderFileUpload, BulkIDeliverOrderFileUpload, ApplicationDbContext>, IBulkIDeliverOrderFileUploadRepository
    {
        public BulkIDeliverOrderFileUploadRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<BulkIDeliverOrderFileUpload> FindByIdAsync(int bulkIDeliverOrderFileUploadId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.BulkIDeliverOrderFileUploadId == bulkIDeliverOrderFileUploadId, cancellationToken);
        }

        public async Task<List<BulkIDeliverOrderFileUpload>> FindByIdsAsync(int[] bulkIDeliverOrderFileUploadIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => bulkIDeliverOrderFileUploadIds.Contains(x.BulkIDeliverOrderFileUploadId), cancellationToken);
        }
    }
}