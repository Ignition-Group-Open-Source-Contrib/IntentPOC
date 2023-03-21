using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IgnProductCatalogueService.Domain.Entities;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.GetProductsAttributesById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductsAttributesByIdQueryHandler : IRequestHandler<GetProductsAttributesByIdQuery, ProductsAttributesDto>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductsAttributesByIdQueryHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<ProductsAttributesDto> Handle(GetProductsAttributesByIdQuery request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _productsRepository.FindByIdAsync(request.ProductsId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Products)} of Id '{request.ProductsId}' could not be found");
            }

            var element = aggregateRoot.Attributes.FirstOrDefault(p => p.Id == request.Id);
            return element == null ? null : element.MapToProductsAttributesDto(_mapper);
        }
    }
}