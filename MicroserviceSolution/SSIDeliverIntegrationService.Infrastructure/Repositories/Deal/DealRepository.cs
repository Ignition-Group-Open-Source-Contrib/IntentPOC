using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Deal;
using SSIDeliverIntegrationService.Domain.Repositories.Deal;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Deal
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DealRepository : RepositoryBase<Domain.Entities.Deal.Deal, Domain.Entities.Deal.Deal, ApplicationDbContext>, IDealRepository
    {
        public DealRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.Deal.Deal> FindByIdAsync(int dealID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.DealID == dealID, cancellationToken);
        }

        public async Task<List<Domain.Entities.Deal.Deal>> FindByIdsAsync(int[] dealIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => dealIDs.Contains(x.DealID), cancellationToken);
        }
    }
}