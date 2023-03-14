using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Admin;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Admin
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface ICityRepository : IRepository<City, City>
    {

        [IntentManaged(Mode.Fully)]
        Task<City> FindByIdAsync(int cityID, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<City>> FindByIdsAsync(int[] cityIDs, CancellationToken cancellationToken = default);
    }
}