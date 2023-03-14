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
    public interface IProvinceRepository : IRepository<Province, Province>
    {

        [IntentManaged(Mode.Fully)]
        Task<Province> FindByIdAsync(int provinceID, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Province>> FindByIdsAsync(int[] provinceIDs, CancellationToken cancellationToken = default);
    }
}