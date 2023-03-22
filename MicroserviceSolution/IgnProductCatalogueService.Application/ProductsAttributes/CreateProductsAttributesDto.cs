using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes
{

    public class CreateProductsAttributesDto
    {
        public CreateProductsAttributesDto()
        {
        }

        public static CreateProductsAttributesDto Create(
            string name,
            string type,
            string? value)
        {
            return new CreateProductsAttributesDto
            {
                Name = name,
                Type = type,
                Value = value,
            };
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string? Value { get; set; }

    }
}