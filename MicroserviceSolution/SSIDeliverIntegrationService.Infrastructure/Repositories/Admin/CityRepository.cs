using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using SSIDeliverIntegrationService.Domain.Entities.Admin;
using SSIDeliverIntegrationService.Domain.Repositories.Admin;
using SSIDeliverIntegrationService.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.Repositories.Admin
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CityRepository : RepositoryBase<City, City, ApplicationDbContext>, ICityRepository
    {
        public CityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<City> FindByIdAsync(int cityID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CityID == cityID, cancellationToken);
        }

        public async Task<List<City>> FindByIdsAsync(int[] cityIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => cityIDs.Contains(x.CityID), cancellationToken);
        }
    }
}