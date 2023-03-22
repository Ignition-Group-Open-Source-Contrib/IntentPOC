using System;
using System.Collections.Generic;
using AutoMapper;
using IgnProductCatalogueService.Application.Common.Mappings;
using IgnProductCatalogueService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes
{

    public class ProductsAttributesDto : IMapFrom<Attributes>
    {
        public ProductsAttributesDto()
        {
        }

        public static ProductsAttributesDto Create(
            Guid productsId,
            Guid id,
            string name,
            string type,
            string? value,
            string label,
            string? description,
            IEnumerable<string>? options)
        {
            return new ProductsAttributesDto
            {
                ProductsId = productsId,
                Id = id,
                Name = name,
                Type = type,
                Value = value,
                Label = label,
                Description = description,
                Options = options,
            };
        }

        public Guid ProductsId { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string? Value { get; set; }

        public string Label { get; set; }

        public string? Description { get; set; }

        public IEnumerable<string>? Options { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attributes, ProductsAttributesDto>();
        }
    }
}