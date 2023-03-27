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
    public interface ITariffRepository : IRepository<Tariff, Tariff>
    {

        [IntentManaged(Mode.Fully)]
        Task<Tariff> FindByIdAsync(int tariffID, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Tariff>> FindByIdsAsync(int[] tariffIDs, CancellationToken cancellationToken = default);
    }
}