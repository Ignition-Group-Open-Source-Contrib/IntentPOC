using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IVwGetCustomerAddressRepository : IRepository<VwGetCustomerAddress, VwGetCustomerAddress>
    {

        [IntentManaged(Mode.Fully)]
        Task<VwGetCustomerAddress> FindByIdAsync(int customerAddressId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<VwGetCustomerAddress>> FindByIdsAsync(int[] customerAddressIds, CancellationToken cancellationToken = default);

        Task<List<VwGetCustomerAddress>> FindByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default);
    }
}