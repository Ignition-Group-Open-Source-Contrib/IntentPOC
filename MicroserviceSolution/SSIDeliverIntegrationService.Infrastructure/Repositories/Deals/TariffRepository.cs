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
    public class TariffRepository : RepositoryBase<Tariff, Tariff, ApplicationDbContext>, ITariffRepository
    {
        public TariffRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Tariff> FindByIdAsync(int tariffID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.TariffID == tariffID, cancellationToken);
        }

        public async Task<List<Tariff>> FindByIdsAsync(int[] tariffIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => tariffIDs.Contains(x.TariffID), cancellationToken);
        }
    }
}