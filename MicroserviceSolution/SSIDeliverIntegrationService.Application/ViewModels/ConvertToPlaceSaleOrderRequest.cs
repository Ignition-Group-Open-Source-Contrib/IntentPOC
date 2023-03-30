using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Entities;
using SSIDeliverIntegrationService.Domain.Entities.Admin;
using SSIDeliverIntegrationService.Domain.Entities.Cust;
using SSIDeliverIntegrationService.Domain.Entities.Ord;
using System.Collections.Generic;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class ConvertToPlaceSaleOrderRequest
    {
        public ConvertToPlaceSaleOrderRequest()
        {
        }

        public static ConvertToPlaceSaleOrderRequest Create(
            Order orderDetails,
            Customer customerDetails,
            List<CustomerContact> customerContactDetails,
            List<VwGetCustomerAddress> customerAddressDetails,
            List<City> cities,
            List<Province> provinces
            )
        {
            return new ConvertToPlaceSaleOrderRequest
            {
                OrderDetails = orderDetails,
                CustomerDetails = customerDetails,
                CustomerContactDetails = customerContactDetails,
                CustomerAddressDetails = customerAddressDetails,
                Cities = cities,
                Provinces = provinces
            };
        }

        public Order OrderDetails { get; set; }
        public Customer CustomerDetails { get; set; }
        public List<CustomerContact> CustomerContactDetails { get; set; }
        public List<VwGetCustomerAddress> CustomerAddressDetails { get; set; }
        public List<City> Cities { get; set; }
        public List<Province> Provinces { get; set; }
    }
}