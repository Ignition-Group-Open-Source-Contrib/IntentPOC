using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Deals;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Deals
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IDealRepository : IRepository<Deal, Deal>
    {

        [IntentManaged(Mode.Fully)]
        Task<Deal> FindByIdAsync(int dealID, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Deal>> FindByIdsAsync(int[] dealIDs, CancellationToken cancellationToken = default);
    }
}