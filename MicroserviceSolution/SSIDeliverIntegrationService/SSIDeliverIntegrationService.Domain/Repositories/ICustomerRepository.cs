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
    public interface ICustomerRepository : IRepository<Customer, Customer>
    {

        [IntentManaged(Mode.Fully)]
        Task<Customer> FindByIdAsync(int customerId, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Customer>> FindByIdsAsync(int[] customerIds, CancellationToken cancellationToken = default);
    }
}