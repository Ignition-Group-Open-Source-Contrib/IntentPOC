using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes
{

    public class UpdateProductsRelationshipsDto
    {
        public UpdateProductsRelationshipsDto()
        {
        }

        public static UpdateProductsRelationshipsDto Create(
            string productId,
            Guid id)
        {
            return new UpdateProductsRelationshipsDto
            {
                ProductId = productId,
                Id = id,
            };
        }

        public string ProductId { get; set; }

        public Guid Id { get; set; }

    }
}