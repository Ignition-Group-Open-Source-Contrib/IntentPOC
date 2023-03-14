using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities.Cust;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Repositories.Cust
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface ICustomerAddressRepository : IRepository<CustomerAddress, CustomerAddress>
    {

        [IntentManaged(Mode.Fully)]
        Task<CustomerAddress> FindByIdAsync(int customerAddressID, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<CustomerAddress>> FindByIdsAsync(int[] customerAddressIDs, CancellationToken cancellationToken = default);
    }
}