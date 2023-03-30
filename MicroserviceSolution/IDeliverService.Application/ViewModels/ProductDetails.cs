using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application.ViewModels
{

    public class ProductDetails
    {
        public ProductDetails()
        {
        }

        public static ProductDetails Create(
            int id,
            string name,
            string sku,
            string notes,
            string created_at,
            string updated_at)
        {
            return new ProductDetails
            {
                Id = id,
                Name = name,
                Sku = sku,
                Notes = notes,
                Created_at = created_at,
                Updated_at = updated_at,
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Sku { get; set; }

        public string Notes { get; set; }

        public string Created_at { get; set; }

        public string Updated_at { get; set; }

    }
}