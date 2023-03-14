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
    
        Task<string> GetSaleOrder(string token, int id);
        [Post("/sale-orders")]
     
        [Get("/sale-orders/{id}/tracking-events")]
        Task<string> GetTrackingEvents(string token, int id);
        
        [Get("/channels")]
        Task<string> SaleChannels(string token);
        [Get("/sale-orders/{id}/tracking-pod")]
        Task<string> GetTrackingPOD(string token, int id);
    }
    public class IDeliverApi : IIDeliverApi
    {
        private IIDeliverApi client;

        readonly IConfiguration configuration;

       
        public IDeliverApi(IConfiguration configuration)
        {
            this.configuration = configuration;
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
                BaseAddress = new Uri(configuration.GetValue<string>("marketic:ideliver:baseurl")),
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
                BaseAddress = new Uri(configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                }
            });
            return client.GetTrackingEvents(token, id);
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
                BaseAddress = new Uri(configuration.GetValue<string>("marketic:ideliver:baseurl")),
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
                BaseAddress = new Uri(configuration.GetValue<string>("marketic:ideliver:baseurl")),
                DefaultRequestHeaders =
                {
                    { "Authorization", token },
                    { "Accept","application/json"}
                },                
            });
            return client.GetProduct(token, sku);
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
                BaseAddress = new Uri(configuration.GetValue<string>("marketic:ideliver:baseurl")),
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
                BaseAddress = new Uri(configuration.GetValue<string>("marketic:ideliver:baseurl")),
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
