using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoCRUDSample.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.GetProductEntities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductEntitiesQueryHandler : IRequestHandler<GetProductEntitiesQuery, List<ProductEntityDto>>
    {
        private readonly IProductEntityRepository _productEntityRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductEntitiesQueryHandler(IProductEntityRepository productEntityRepository, IMapper mapper)
        {
            _productEntityRepository = productEntityRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<ProductEntityDto>> Handle(GetProductEntitiesQuery request, CancellationToken cancellationToken)
        {
            var productEntities = await _productEntityRepository.FindAllAsync(cancellationToken);
            return productEntities.MapToProductEntityDtoList(_mapper);
        }
    }
}