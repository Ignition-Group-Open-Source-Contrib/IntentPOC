using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class SaleChannelsResponseModel
    {
        public SaleChannelsResponseModel()
        {
        }

        public static SaleChannelsResponseModel Create(
            int id,
            string name,
            string tel,
            string email,
            string website,
            string address_line_1,
            string address_line_2,
            string address_suburb,
            string address_city,
            string address_postcode)
        {
            return new SaleChannelsResponseModel
            {
                Id = id,
                Name = name,
                Tel = tel,
                Email = email,
                Website = website,
                Address_line_1 = address_line_1,
                Address_line_2 = address_line_2,
                Address_suburb = address_suburb,
                Address_city = address_city,
                Address_postcode = address_postcode,
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Address_line_1 { get; set; }

        public string Address_line_2 { get; set; }

        public string Address_suburb { get; set; }

        public string Address_city { get; set; }

        public string Address_postcode { get; set; }

    }
}