using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class SaleOrderItemsRequestModel
    {
        public SaleOrderItemsRequestModel()
        {
        }

        public static SaleOrderItemsRequestModel Create(
            string sku,
            int qty,
            string description)
        {
            return new SaleOrderItemsRequestModel
            {
                Sku = sku,
                Qty = qty,
                Description = description,
            };
        }

        public string Sku { get; set; }

        public int Qty { get; set; }

        public string Description { get; set; }

    }
}