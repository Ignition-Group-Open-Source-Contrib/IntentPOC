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
    public class VASXProviderSpecificRepository : RepositoryBase<VASXProviderSpecific, VASXProviderSpecific, ApplicationDbContext>, IVASXProviderSpecificRepository
    {
        public VASXProviderSpecificRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VASXProviderSpecific> FindByIdAsync(int vASXProviderSpecificId, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.VASXProviderSpecificId == vASXProviderSpecificId, cancellationToken);
        }

        public async Task<List<VASXProviderSpecific>> FindByIdsAsync(int[] vASXProviderSpecificIds, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => vASXProviderSpecificIds.Contains(x.VASXProviderSpecificId), cancellationToken);
        }
    }
}