using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using IgnProductCatalogueService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues
{
    public static class ProductCatalogueDtoMappingExtensions
    {
        public static ProductCatalogueDto MapToProductCatalogueDto(this ProductCatalogue projectFrom, IMapper mapper)
        {
            return mapper.Map<ProductCatalogueDto>(projectFrom);
        }

        public static List<ProductCatalogueDto> MapToProductCatalogueDtoList(this IEnumerable<ProductCatalogue> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToProductCatalogueDto(mapper)).ToList();
        }
    }
}