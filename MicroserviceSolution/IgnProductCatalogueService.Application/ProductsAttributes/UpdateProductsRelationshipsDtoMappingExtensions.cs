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
    public static class UpdateProductsRelationshipsDtoMappingExtensions
    {
        public static UpdateProductsRelationshipsDto MapToUpdateProductsRelationshipsDto(this Relationships projectFrom, IMapper mapper)
        {
            return mapper.Map<UpdateProductsRelationshipsDto>(projectFrom);
        }

        public static List<UpdateProductsRelationshipsDto> MapToUpdateProductsRelationshipsDtoList(this IEnumerable<Relationships> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToUpdateProductsRelationshipsDto(mapper)).ToList();
        }
    }
}