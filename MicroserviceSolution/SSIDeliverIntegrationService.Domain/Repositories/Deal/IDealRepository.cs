using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Deal;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Deal
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IDealRepository : IRepository<Entities.Deal.Deal, Entities.Deal.Deal>
    {

        [IntentManaged(Mode.Fully)]
        Task<Entities.Deal.Deal> FindByIdAsync(int dealID, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Entities.Deal.Deal>> FindByIdsAsync(int[] dealIDs, CancellationToken cancellationToken = default);
    }
}