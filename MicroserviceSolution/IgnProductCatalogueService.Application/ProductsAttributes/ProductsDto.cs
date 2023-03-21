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

    public class ProductsDto : IMapFrom<Products>
    {
        public ProductsDto()
        {
        }

        public static ProductsDto Create(
            Guid id,
            string sku,
            string? label,
            string status,
            DateTime createdDate,
            DateTime modifiedDate)
        {
            return new ProductsDto
            {
                Id = id,
                Sku = sku,
                Label = label,
                Status = status,
                CreatedDate = createdDate,
                ModifiedDate = modifiedDate,
            };
        }

        public Guid Id { get; set; }

        public string Sku { get; set; }

        public string? Label { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Products, ProductsDto>();
        }
    }
}