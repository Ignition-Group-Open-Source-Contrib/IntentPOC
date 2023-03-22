using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes
{

    public class CreateProductsRelationshipsDto
    {
        public CreateProductsRelationshipsDto()
        {
        }

        public static CreateProductsRelationshipsDto Create(
            string productId)
        {
            return new CreateProductsRelationshipsDto
            {
                ProductId = productId,
            };
        }

        public string ProductId { get; set; }

    }
}