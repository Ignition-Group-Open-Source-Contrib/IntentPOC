using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Deals;
using SSIDeliverIntegrationService.Domain.Repositories.Deals;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Deals
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DealRepository : RepositoryBase<Deal, Deal, ApplicationDbContext>, IDealRepository
    {
        public DealRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Deal> FindByIdAsync(int dealID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.DealID == dealID, cancellationToken);
        }

        public async Task<List<Deal>> FindByIdsAsync(int[] dealIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => dealIDs.Contains(x.DealID), cancellationToken);
        }
    }
}