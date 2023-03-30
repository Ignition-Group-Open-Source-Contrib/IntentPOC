using IDeliverService.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IDeliverService.Application.ThirdPartyServices
{
    public interface IIDeliverApi
    {
        [Get("/warehouses")]
        Task<string> Warehouses(string token);

        [Get("/products/{sku}")]
        Task<string> GetProduct(string token, string sku);

        [Post("/products")]
        Task<HttpResponseMessage> CreateProduct(string token, CreateProductRequestModel requestModel);

        [Patch("/products/{sku}")]
        Task<HttpResponseMessage> UpdateProduct(string token, string sku, UpdateProductRequestModel requestModel);

        [Get("/sale-orders/{id}")]
        Task<string> GetSaleOrder(string token, int id);

        [Post("/sale-orders")]
        Task<HttpResponseMessage> CreateSaleOrder(string token, CreateUpdateSaleOrderRequestModel requestModel);

        [Patch("/sale-orders/{id}")]
        Task<string> UpdateSaleOrder(string token, int id, CreateUpdateSaleOrderRequestModel requestModel);

        [Get("/sale-orders/{id}/tracking-events")]
        Task<string> GetTrackingEvents(string token, int id);

        [Patch("/sale-orders/{id}/status")]
        Task<string> UpdateSaleOrderStatus(string token, int id, UpdateOrderStatusRequestModel request);

        [Get("/channels")]
        Task<string> SaleChannels(string token);

        [Get("/sale-orders/{id}/tracking-pod")]
        Task<string> GetTrackingPOD(string token, int id);
    }

    public class IDeliverApi : IIDeliverApi
    {
        private IIDeliverApi client;
        private readonly IConfiguration _configuration;

        public IDeliverApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="requestModel">CreateProductRequestModel requestModel</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> CreateProduct(string token, CreateProductRequestModel requestModel)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.CreateProduct(token, requestModel);
        }

        /// <summary>
        /// Create Sale Order
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="requestModel">CreateUpdateSaleOrderRequestModel requestModel</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> CreateSaleOrder(string token, CreateUpdateSaleOrderRequestModel requestModel)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.CreateSaleOrder(token, requestModel);
        }

        /// <summary>
        /// Get Sale Order
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="id">Sale Order Id</param>
        /// <returns>string</returns>
        public Task<string> GetSaleOrder(string token, int id)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.GetSaleOrder(token, id);
        }

        /// <summary>
        /// Get Tracking Events
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="id">Sale Order Id</param>
        /// <returns>string</returns>
        public Task<string> GetTrackingEvents(string token, int id)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.GetTrackingEvents(token, id);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="sku">Sku</param>
        /// <param name="requestModel">UpdateProductRequestModel requestModel</param>
        /// <returns>HttpResponseMessage</returns>
        public Task<HttpResponseMessage> UpdateProduct(string token, string sku, UpdateProductRequestModel requestModel)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.UpdateProduct(token, sku, requestModel);
        }

        /// <summary>
        /// Update Sale Order
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="id">Sale Order Id</param>
        /// <param name="requestModel">CreateUpdateSaleOrderRequestModel requestModel</param>
        /// <returns>string</returns>
        public Task<string> UpdateSaleOrder(string token, int id, CreateUpdateSaleOrderRequestModel requestModel)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.UpdateSaleOrder(token, id, requestModel);
        }

        /// <summary>
        /// Warehouses
        /// </summary>
        /// <param name="token">API access token</param>
        /// <returns>string</returns>
        public Task<string> Warehouses(string token)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.Warehouses(token);
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="sku">Sku</param>
        /// <returns>string</returns>
        public Task<string> GetProduct(string token, string sku)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                },
            });
            return client.GetProduct(token, sku);
        }

        /// <summary>
        /// Update Sale Order Status
        /// </summary>
        /// <param name="token">API access token</param>
        /// <param name="id">Sale Order Id</param>
        /// <param name="request">UpdateOrderStatusRequestModel request</param>
        /// <returns>string</returns>
        public Task<string> UpdateSaleOrderStatus(string token, int id, UpdateOrderStatusRequestModel request)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.UpdateSaleOrderStatus(token, id, request);
        }

        /// <summary>
        /// Sale Channels
        /// </summary>
        /// <param name="token">API access token</param>
        /// <returns>string</returns>
        public Task<string> SaleChannels(string token)
        {

            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.SaleChannels(token);
        }

        /// <summary>
        /// Get Tracking POD
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<string> GetTrackingPOD(string token, int id)
        {
            client = RestService.For<IIDeliverApi>(new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.GetTrackingPOD(token, id);
        }
    }
}
