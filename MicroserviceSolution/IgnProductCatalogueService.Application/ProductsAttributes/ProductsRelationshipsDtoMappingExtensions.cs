using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using IgnProductCatalogueService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes
{
    public static class ProductsRelationshipsDtoMappingExtensions
    {
        public static ProductsRelationshipsDto MapToProductsRelationshipsDto(this Relationships projectFrom, IMapper mapper)
        {
            return mapper.Map<ProductsRelationshipsDto>(projectFrom);
        }

        public static List<ProductsRelationshipsDto> MapToProductsRelationshipsDtoList(this IEnumerable<Relationships> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToProductsRelationshipsDto(mapper)).ToList();
        }
    }
}