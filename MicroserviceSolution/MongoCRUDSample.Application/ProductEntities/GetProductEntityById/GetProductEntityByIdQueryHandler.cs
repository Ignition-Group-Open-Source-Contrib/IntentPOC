using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoCRUDSample.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.GetProductEntityById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductEntityByIdQueryHandler : IRequestHandler<GetProductEntityByIdQuery, ProductEntityDto>
    {
        private readonly IProductEntityRepository _productEntityRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductEntityByIdQueryHandler(IProductEntityRepository productEntityRepository, IMapper mapper)
        {
            _productEntityRepository = productEntityRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<ProductEntityDto> Handle(GetProductEntityByIdQuery request, CancellationToken cancellationToken)
        {
            var productEntity = await _productEntityRepository.FindByIdAsync(request.Id, cancellationToken);
            return productEntity.MapToProductEntityDto(_mapper);
        }
    }
}