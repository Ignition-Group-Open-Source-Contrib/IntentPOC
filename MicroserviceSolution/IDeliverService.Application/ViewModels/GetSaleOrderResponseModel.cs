using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application.ViewModels
{

    public class GetSaleOrderResponseModel
    {
        public GetSaleOrderResponseModel()
        {
        }

        public static GetSaleOrderResponseModel Create(
            int id,
            string reference,
            string recipient_name,
            string recipient_id,
            string recipient_email,
            string recipient_tel_1,
            string recipient_tel_2,
            string address_building,
            string address_company,
            string address_line_1,
            string address_line_2,
            string address_suburb,
            string address_city,
            string address_province,
            string address_postcode,
            string residential_address_building,
            string residential_address_line_1,
            string residential_address_line_2,
            string residential_address_suburb,
            string residential_address_city,
            string residential_address_province,
            string residential_address_postcode,
            string extra_info_1,
            string extra_info_2,
            string delivery_notes,
            string status,
            string status_text,
            string warehouse_id,
            Courier courier,
            string created_at,
            string updated_at)
        {
            return new GetSaleOrderResponseModel
            {
                Id = id,
                Reference = reference,
                Recipient_name = recipient_name,
                Recipient_id = recipient_id,
                Recipient_email = recipient_email,
                Recipient_tel_1 = recipient_tel_1,
                Recipient_tel_2 = recipient_tel_2,
                Address_building = address_building,
                Address_company = address_company,
                Address_line_1 = address_line_1,
                Address_line_2 = address_line_2,
                Address_suburb = address_suburb,
                Address_city = address_city,
                Address_province = address_province,
                Address_postcode = address_postcode,
                Residential_address_building = residential_address_building,
                Residential_address_line_1 = residential_address_line_1,
                Residential_address_line_2 = residential_address_line_2,
                Residential_address_suburb = residential_address_suburb,
                Residential_address_city = residential_address_city,
                Residential_address_province = residential_address_province,
                Residential_address_postcode = residential_address_postcode,
                Extra_info_1 = extra_info_1,
                Extra_info_2 = extra_info_2,
                Delivery_notes = delivery_notes,
                Status = status,
                Status_text = status_text,
                Warehouse_id = warehouse_id,
                Courier = courier,
                Created_at = created_at,
                Updated_at = updated_at,
            };
        }

        public int Id { get; set; }

        public string Reference { get; set; }

        public string Recipient_name { get; set; }

        public string Recipient_id { get; set; }

        public string Recipient_email { get; set; }

        public string Recipient_tel_1 { get; set; }

        public string Recipient_tel_2 { get; set; }

        public string Address_building { get; set; }

        public string Address_company { get; set; }

        public string Address_line_1 { get; set; }

        public string Address_line_2 { get; set; }

        public string Address_suburb { get; set; }

        public string Address_city { get; set; }

        public string Address_province { get; set; }

        public string Address_postcode { get; set; }

        public string Residential_address_building { get; set; }

        public string Residential_address_line_1 { get; set; }

        public string Residential_address_line_2 { get; set; }

        public string Residential_address_suburb { get; set; }

        public string Residential_address_city { get; set; }

        public string Residential_address_province { get; set; }

        public string Residential_address_postcode { get; set; }

        public string Extra_info_1 { get; set; }

        public string Extra_info_2 { get; set; }

        public string Delivery_notes { get; set; }

        public string Status { get; set; }

        public string Status_text { get; set; }

        public string Warehouse_id { get; set; }

        public Courier Courier { get; set; }

        public string Created_at { get; set; }

        public string Updated_at { get; set; }

    }
}