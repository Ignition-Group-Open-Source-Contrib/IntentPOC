using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.GetProductsById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, ProductsDto>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductsByIdQueryHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<ProductsDto> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsRepository.FindByIdAsync(request.Id, cancellationToken);
            return products.MapToProductsDto(_mapper);
        }
    }
}