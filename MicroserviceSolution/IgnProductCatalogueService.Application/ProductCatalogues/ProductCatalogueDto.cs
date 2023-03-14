using System;
using System.Collections.Generic;
using AutoMapper;
using IgnProductCatalogueService.Application.Common.Mappings;
using IgnProductCatalogueService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues
{

    public class ProductCatalogueDto : IMapFrom<ProductCatalogue>
    {
        public ProductCatalogueDto()
        {
        }

        public static ProductCatalogueDto Create(
            string id,
            string sku,
            string label,
            string status,
            string parentId,
            Dictionary<string, object> attributes,
            DateTime createdDate,
            DateTime modifiedDate)
        {
            return new ProductCatalogueDto
            {
                Id = id,
                Sku = sku,
                Label = label,
                Status = status,
                ParentId = parentId,
                Attributes = attributes,
                CreatedDate = createdDate,
                ModifiedDate = modifiedDate,
            };
        }

        public string Id { get; set; }

        public string Sku { get; set; }

        public string Label { get; set; }

        public string Status { get; set; }

        public string ParentId { get; set; }

        public Dictionary<string, object> Attributes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCatalogue, ProductCatalogueDto>();
        }
    }
}