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
            string? label,
            string status,
            string? parentId,
            Dictionary<string, string>? attributes,
            DateTime createdDate,
            DateTime modifiedDate,
            Dictionary<string, string>? relationships)
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
                Relationships = relationships,
            };
        }

        public string Id { get; set; }

        public string Sku { get; set; }

        public string? Label { get; set; }

        public string Status { get; set; }

        public string? ParentId { get; set; }

        public Dictionary<string, string>? Attributes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Dictionary<string, string>? Relationships { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCatalogue, ProductCatalogueDto>();
        }
    }
}