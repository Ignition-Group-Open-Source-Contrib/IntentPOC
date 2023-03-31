using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class SaleOrderItemViewModel
    {
        public SaleOrderItemViewModel()
        {
        }

        public static SaleOrderItemViewModel Create(
            List<SaleOrderItemsRequestModel> saleOrderItems,
            string tariffDetails)
        {
            return new SaleOrderItemViewModel
            {
                SaleOrderItems = saleOrderItems,
                TariffDetails = tariffDetails,
            };
        }

        public List<SaleOrderItemsRequestModel> SaleOrderItems { get; set; }

        public string TariffDetails { get; set; }

    }
}