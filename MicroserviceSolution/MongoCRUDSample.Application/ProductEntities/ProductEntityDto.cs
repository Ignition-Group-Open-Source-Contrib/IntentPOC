using System;
using System.Collections.Generic;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MongoCRUDSample.Application.Common.Mappings;
using MongoCRUDSample.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities
{

    public class ProductEntityDto : IMapFrom<ProductEntity>
    {
        public ProductEntityDto()
        {
        }

        public static ProductEntityDto Create(
            string id,
            string productName,
            string sku,
            decimal productPrice,
            DateTime createdDate,
            DateTime updatedDate)
        {
            return new ProductEntityDto
            {
                Id = id,
                ProductName = productName,
                Sku = sku,
                ProductPrice = productPrice,
                CreatedDate = createdDate,
                UpdatedDate = updatedDate,
            };
        }

        public string Id { get; set; }

        public string ProductName { get; set; }

        public string Sku { get; set; }

        public decimal ProductPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductEntity, ProductEntityDto>();
        }
    }
}