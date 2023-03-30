using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public class SaleOrderItemsRequestModel
    {
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