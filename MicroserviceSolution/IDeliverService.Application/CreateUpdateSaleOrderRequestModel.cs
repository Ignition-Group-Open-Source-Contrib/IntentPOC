using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application
{

    public class CreateUpdateSaleOrderRequestModel
    {
        public CreateUpdateSaleOrderRequestModel()
        {
        }

        public static CreateUpdateSaleOrderRequestModel Create(
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
            int channel_id,
            int warehouse_id,
            List<SaleOrderItemsRequestModel> sale_order_items)
        {
            return new CreateUpdateSaleOrderRequestModel
            {
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
                Channel_id = channel_id,
                Warehouse_id = warehouse_id,
                Sale_order_items = sale_order_items,
            };
        }

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

        public int Channel_id { get; set; }

        public int Warehouse_id { get; set; }

        public List<SaleOrderItemsRequestModel> Sale_order_items { get; set; }

    }
}