using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MongoCRUDSample.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities
{
    public static class ProductEntityDtoMappingExtensions
    {
        public static ProductEntityDto MapToProductEntityDto(this ProductEntity projectFrom, IMapper mapper)
        {
            return mapper.Map<ProductEntityDto>(projectFrom);
        }

        public static List<ProductEntityDto> MapToProductEntityDtoList(this IEnumerable<ProductEntity> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToProductEntityDto(mapper)).ToList();
        }
    }
}