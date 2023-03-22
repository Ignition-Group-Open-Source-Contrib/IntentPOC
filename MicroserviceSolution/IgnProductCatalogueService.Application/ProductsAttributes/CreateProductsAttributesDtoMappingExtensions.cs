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
    public static class CreateProductsAttributesDtoMappingExtensions
    {
        public static CreateProductsAttributesDto MapToCreateProductsAttributesDto(this Attributes projectFrom, IMapper mapper)
        {
            return mapper.Map<CreateProductsAttributesDto>(projectFrom);
        }

        public static List<CreateProductsAttributesDto> MapToCreateProductsAttributesDtoList(this IEnumerable<Attributes> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToCreateProductsAttributesDto(mapper)).ToList();
        }
    }
}