using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes
{

    public class UpdateProductsAttributesDto
    {
        public UpdateProductsAttributesDto()
        {
        }

        public static UpdateProductsAttributesDto Create(
            string name,
            string label,
            string? description,
            string type,
            string? value,
            IEnumerable<string>? options,
            Guid id)
        {
            return new UpdateProductsAttributesDto
            {
                Name = name,
                Label = label,
                Description = description,
                Type = type,
                Value = value,
                Options = options,
                Id = id,
            };
        }

        public string Name { get; set; }

        public string Label { get; set; }

        public string? Description { get; set; }

        public string Type { get; set; }

        public string? Value { get; set; }

        public IEnumerable<string>? Options { get; set; }

        public Guid Id { get; set; }

    }
}