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

    public class UpdateProductsRelationshipsDto : IMapFrom<Relationships>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Relationships, UpdateProductsRelationshipsDto>();
        }

    }
}