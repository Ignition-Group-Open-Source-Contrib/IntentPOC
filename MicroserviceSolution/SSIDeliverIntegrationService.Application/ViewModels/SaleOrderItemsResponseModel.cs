using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class SaleOrderItemsResponseModel
    {
        public SaleOrderItemsResponseModel()
        {
        }

        public static SaleOrderItemsResponseModel Create(
            int id,
            int qty,
            string description,
            ProductDetails product,
            string created_at,
            string updated_at)
        {
            return new SaleOrderItemsResponseModel
            {
                Id = id,
                Qty = qty,
                Description = description,
                Product = product,
                Created_at = created_at,
                Updated_at = updated_at,
            };
        }

        public int Id { get; set; }

        public int Qty { get; set; }

        public string Description { get; set; }

        public ProductDetails Product { get; set; }

        public string Created_at { get; set; }

        public string Updated_at { get; set; }

    }
}