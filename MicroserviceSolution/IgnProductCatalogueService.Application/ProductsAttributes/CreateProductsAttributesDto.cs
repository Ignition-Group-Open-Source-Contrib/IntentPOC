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

    public class CreateProductsAttributesDto : IMapFrom<Attributes>
    {
        public CreateProductsAttributesDto()
        {
        }

        public static CreateProductsAttributesDto Create(
            string name,
            string type,
            string? value,
            string label,
            string? description,
            IEnumerable<string>? options)
        {
            return new CreateProductsAttributesDto
            {
                Name = name,
                Type = type,
                Value = value,
                Label = label,
                Description = description,
                Options = options,
            };
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string? Value { get; set; }

        public string Label { get; set; }

        public string? Description { get; set; }

        public IEnumerable<string>? Options { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attributes, CreateProductsAttributesDto>();
        }

    }
}