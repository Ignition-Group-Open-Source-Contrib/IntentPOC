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

    public class ProductsRelationshipsDto : IMapFrom<Relationships>
    {
        public ProductsRelationshipsDto()
        {
        }

        public static ProductsRelationshipsDto Create(
            Guid productsId,
            Guid id,
            string productId)
        {
            return new ProductsRelationshipsDto
            {
                ProductsId = productsId,
                Id = id,
                ProductId = productId,
            };
        }

        public Guid ProductsId { get; set; }

        public Guid Id { get; set; }

        public string ProductId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Relationships, ProductsRelationshipsDto>();
        }
    }
}