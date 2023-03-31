using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.WebUtilities;
using SSIDeliverIntegrationService.Application.Common.Exceptions;
using SSIDeliverIntegrationService.Application.IDeliverService;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Dapr.AspNetCore.ServiceInvocation.HttpClient", Version = "1.0")]

namespace SSIDeliverIntegrationService.Infrastructure.HttpClients
{
    public class IDeliverServiceHttpClient : IIDeliverClient
    {
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly HttpClient _httpClient;

        public IDeliverServiceHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<TrackingPODResponseModel> GetTrackingPODAsync(int id, string token, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/gettrackingpod";
            var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<TrackingPODResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<GetSaleOrderResponseModel> UpdateSaleOrderStatusAsync(string token, int id, UpdateOrderStatusRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/updatesaleorderstatus";
            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<GetSaleOrderResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<TrackingEventsResponseModel> GetTrackingEventsAsync(string token, int id, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/gettrackingevents";
            var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<TrackingEventsResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<List<WarehouseResponseModel>> WarehousesAsync(string token, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/warehouses";
            var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<List<WarehouseResponseModel>>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<CreateProductResponseModel> GetProductAsync(string token, string sku, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/getproduct";
            var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<CreateProductResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<CreateProductResponseModel> CreateProductAsync(string token, CreateProductRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/createproduct";
            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<CreateProductResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<CreateProductResponseModel> UpdateProductAsync(string token, string sku, UpdateProductRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/updateproduct";
            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<CreateProductResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<GetSaleOrderResponseModel> GetSaleOrderAsync(string token, int id, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/getsaleorder";
            var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<GetSaleOrderResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<CreateUpdateSaleOrderResponseModel> CreateSaleOrderAsync(string token, CreateUpdateSaleOrderRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/createsaleorder";
            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<CreateUpdateSaleOrderResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<CreateUpdateSaleOrderResponseModel> UpdateSaleOrderAsync(string token, int id, CreateUpdateSaleOrderRequestModel requestModel, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/updatesaleorder";
            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<CreateUpdateSaleOrderResponseModel>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public async Task<List<SaleChannelsResponseModel>> SalesChannelsAsync(string token, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"api/ideliver/saleschannels";
            var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(token, _serializerOptions);
            request.Content = new StringContent(content, Encoding.Default, "application/json");

            using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw await HttpClientRequestException.Create(_httpClient.BaseAddress, request, response, cancellationToken).ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
                {
                    return default;
                }

                using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                {
                    return await JsonSerializer.DeserializeAsync<List<SaleChannelsResponseModel>>(contentStream, _serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}