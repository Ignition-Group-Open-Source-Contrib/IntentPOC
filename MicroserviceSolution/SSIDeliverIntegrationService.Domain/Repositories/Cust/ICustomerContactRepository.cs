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
    public interface ICustomerContactRepository : IRepository<CustomerContact, CustomerContact>
    {

        [IntentManaged(Mode.Fully)]
        Task<CustomerContact> FindByIdAsync(int customerContactId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<CustomerContact>> FindByIdsAsync(int[] customerContactIds, CancellationToken cancellationToken = default);

        Task<List<CustomerContact>> FindByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default);
    }
}