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
    public static class ProductsDtoMappingExtensions
    {
        public static ProductsDto MapToProductsDto(this Products projectFrom, IMapper mapper)
        {
            return mapper.Map<ProductsDto>(projectFrom);
        }

        public static List<ProductsDto> MapToProductsDtoList(this IEnumerable<Products> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToProductsDto(mapper)).ToList();
        }
    }
}