using SSIDeliverIntegrationService.Domain.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SSIDeliverIntegrationService.Application.Common.Enum.Enumerator;

namespace SSIDeliverIntegrationService.Application.ViewModels
{
    public static class Extensions
    {
        public static CreateUpdateSaleOrderRequestModel ConvertIntoCreateSaleRequest(this ConvertToPlaceSaleOrderRequest convertToCreateSaleRequest)
        {
            if (convertToCreateSaleRequest == null) return null;
            var deliveryAdddress = convertToCreateSaleRequest.CustomerAddressDetails.Where(i => i.AddressTypeId == (int)AddressType.Delivery).FirstOrDefault();
            var residentialAddress = convertToCreateSaleRequest.CustomerAddressDetails.Where(i => i.AddressTypeId == (int)AddressType.Residential).FirstOrDefault();
            var createUpdateSaleOrderRequestModel = new CreateUpdateSaleOrderRequestModel()
            {
                Reference = convertToCreateSaleRequest.OrderDetails.BasketReference,
                Recipient_name = convertToCreateSaleRequest.CustomerDetails.FullName,
                Recipient_id = convertToCreateSaleRequest.CustomerDetails.IdNumber,
                Recipient_email = convertToCreateSaleRequest.CustomerContactDetails?.Where(i => i.ContactTypeId == (int)ContactType.EmailAddress).Select(x => x.Contact).LastOrDefault(),
                Recipient_tel_1 = convertToCreateSaleRequest.CustomerContactDetails?.Where(i => i.ContactTypeId == (int)ContactType.MobileNumber).Select(x => x.Contact).LastOrDefault(),
                Recipient_tel_2 = convertToCreateSaleRequest.CustomerContactDetails?.Where(i => i.ContactTypeId == (int)ContactType.WorkNumber).Select(x => x.Contact).LastOrDefault(),
                Address_building = deliveryAdddress?.Building,
                Address_company = deliveryAdddress?.Company,
                Address_line_1 = $"{deliveryAdddress?.StreetName}, {deliveryAdddress?.StreetNum}",
                Address_suburb = deliveryAdddress?.Suburb,
                Address_city = deliveryAdddress.CityName,
                Address_postcode = deliveryAdddress?.PostCode,
                Address_province = deliveryAdddress?.ProvinceName,
                Residential_address_building = residentialAddress?.Building,
                Residential_address_line_1 = $"{residentialAddress?.StreetName}, {residentialAddress?.StreetNum}",
                Residential_address_suburb = residentialAddress?.Suburb,
                Residential_address_city = residentialAddress?.CityName,
                Residential_address_province = residentialAddress?.ProvinceName,
                Residential_address_postcode = residentialAddress?.PostCode,
                Delivery_notes = deliveryAdddress?.Notes
            };
            return createUpdateSaleOrderRequestModel;
        }

        public static CreateProductRequestModel ConvertIntoProductRequest(this Product product, ProductDimensions productDimensions)
        {
            if (product == null)
            {
                return null;
            }

            bool hasDimension = false;
            if (productDimensions != null)
            {
                hasDimension = true;
            }
            return new CreateProductRequestModel
            {
                Sku = product.ProductId.ToString(),
                Name = product.Title,
                Price = product.Price,
                Width = hasDimension ? productDimensions.Breadth.GetValueOrDefault(0) : 0,
                Length = hasDimension ? productDimensions.Length.GetValueOrDefault(0) : 0,
                Height = hasDimension ? productDimensions.Height.GetValueOrDefault(0) : 0,
                Weight = hasDimension ? productDimensions.Weight.GetValueOrDefault(0) : 0,
                Has_serial_numbers = true
            };
        }

        public static UpdateProductRequestModel ConvertIntoUpdateProductRequest(this CreateProductRequestModel product)
        {
            if (product == null)
            {
                return null;
            }

            return new UpdateProductRequestModel
            {
                Name = product.Name,
                Price = product.Price,
                Width = product.Width,
                Length = product.Length,
                Height = product.Height,
                Weight = product.Weight,
                Has_serial_numbers = product.Has_serial_numbers
            };
        }
    }
}
