using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.ServiceContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public interface IIDeliverClient : IDisposable
    {
        Task<List<SaleChannelsResponseModel>> GetSalesChannelAsync(string token, CancellationToken cancellationToken = default);
    }
}