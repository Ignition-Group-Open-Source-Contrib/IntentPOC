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
    public class DealProductMappingRepository : RepositoryBase<DealProductMapping, DealProductMapping, ApplicationDbContext>, IDealProductMappingRepository
    {
        public DealProductMappingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<DealProductMapping> FindByIdAsync(int dealProductMappingId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.DealProductMappingId == dealProductMappingId, cancellationToken);
        }

        public async Task<List<DealProductMapping>> FindByIdsAsync(int[] dealProductMappingIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => dealProductMappingIds.Contains(x.DealProductMappingId), cancellationToken);
        }

        public async Task<List<int?>> FindProductIdsByDealId(int dealId, CancellationToken cancellationToken = default)
        {
            var dealProductMappings = await FindAllAsync(i => i.DealID == dealId && i.Active == true);
            return dealProductMappings.Select(x => x.ProductId).ToList();
        }
    }
}