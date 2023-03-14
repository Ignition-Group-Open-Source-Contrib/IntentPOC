using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogues
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductCataloguesQueryHandler : IRequestHandler<GetProductCataloguesQuery, List<ProductCatalogueDto>>
    {
        private readonly IProductCatalogueRepository _productCatalogueRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductCataloguesQueryHandler(IProductCatalogueRepository productCatalogueRepository, IMapper mapper)
        {
            _productCatalogueRepository = productCatalogueRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<ProductCatalogueDto>> Handle(GetProductCataloguesQuery request, CancellationToken cancellationToken)
        {
            var productCatalogues = await _productCatalogueRepository.FindAllAsync(cancellationToken);
            return productCatalogues.MapToProductCatalogueDtoList(_mapper);
        }
    }
}