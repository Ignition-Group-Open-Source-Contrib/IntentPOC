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
    public class ProvinceRepository : RepositoryBase<Province, Province, ApplicationDbContext>, IProvinceRepository
    {
        public ProvinceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Province> FindByIdAsync(int provinceID, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ProvinceID == provinceID, cancellationToken);
        }

        public async Task<List<Province>> FindByIdsAsync(int[] provinceIDs, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => provinceIDs.Contains(x.ProvinceID), cancellationToken);
        }
    }
}