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
    public static class UpdateProductsAttributesDtoMappingExtensions
    {
        public static UpdateProductsAttributesDto MapToUpdateProductsAttributesDto(this Attributes projectFrom, IMapper mapper)
        {
            return mapper.Map<UpdateProductsAttributesDto>(projectFrom);
        }

        public static List<UpdateProductsAttributesDto> MapToUpdateProductsAttributesDtoList(this IEnumerable<Attributes> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToUpdateProductsAttributesDto(mapper)).ToList();
        }
    }
}