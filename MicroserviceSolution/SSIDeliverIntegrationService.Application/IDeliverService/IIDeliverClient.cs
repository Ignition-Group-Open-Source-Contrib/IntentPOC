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
        Task<TrackingPODResponseModel> GetTrackingPODAsync(int id, string token, CancellationToken cancellationToken = default);
        Task<GetSaleOrderResponseModel> UpdateSaleOrderStatusAsync(string token, int id, UpdateOrderStatusRequestModel request, CancellationToken cancellationToken = default);
        Task<TrackingEventsResponseModel> GetTrackingEventsAsync(string token, int id, CancellationToken cancellationToken = default);
        Task<List<WarehouseResponseModel>> WarehousesAsync(string token, CancellationToken cancellationToken = default);
        Task<CreateProductResponseModel> GetProductAsync(string token, string sku, CancellationToken cancellationToken = default);
        Task<CreateProductResponseModel> CreateProductAsync(string token, CreateProductRequestModel request, CancellationToken cancellationToken = default);
        Task<CreateProductResponseModel> UpdateProductAsync(string token, string sku, UpdateProductRequestModel request, CancellationToken cancellationToken = default);
        Task<GetSaleOrderResponseModel> GetSaleOrderAsync(string token, int id, CancellationToken cancellationToken = default);
        Task<CreateUpdateSaleOrderRequestModel> CreateSaleOrderAsync(string token, CreateUpdateSaleOrderRequestModel request, CancellationToken cancellationToken = default);
        Task<CreateUpdateSaleOrderResponseModel> UpdateSaleOrderAsync(string token, int id, CreateUpdateSaleOrderRequestModel request, CancellationToken cancellationToken = default);
        Task<List<SaleChannelsResponseModel>> SalesChannelsAsync(string token, CancellationToken cancellationToken = default);
    }
}