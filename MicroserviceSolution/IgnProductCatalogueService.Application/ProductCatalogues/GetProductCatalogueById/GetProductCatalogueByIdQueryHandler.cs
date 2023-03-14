using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogueById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductCatalogueByIdQueryHandler : IRequestHandler<GetProductCatalogueByIdQuery, ProductCatalogueDto>
    {
        private readonly IProductCatalogueRepository _productCatalogueRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductCatalogueByIdQueryHandler(IProductCatalogueRepository productCatalogueRepository, IMapper mapper)
        {
            _productCatalogueRepository = productCatalogueRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<ProductCatalogueDto> Handle(GetProductCatalogueByIdQuery request, CancellationToken cancellationToken)
        {
            var productCatalogue = await _productCatalogueRepository.FindByIdAsync(request.Id, cancellationToken);
            return productCatalogue.MapToProductCatalogueDto(_mapper);
        }
    }
}