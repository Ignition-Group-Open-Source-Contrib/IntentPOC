using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IgnProductCatalogueService.Domain.Entities;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.GetProductsRelationships
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductsRelationshipsQueryHandler : IRequestHandler<GetProductsRelationshipsQuery, List<ProductsRelationshipsDto>>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductsRelationshipsQueryHandler(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<ProductsRelationshipsDto>> Handle(GetProductsRelationshipsQuery request, CancellationToken cancellationToken)
        {
            var aggregateRoot = await _productsRepository.FindByIdAsync(request.ProductsId, cancellationToken);
            if (aggregateRoot == null)
            {
                throw new InvalidOperationException($"{nameof(Products)} of Id '{request.ProductsId}' could not be found");
            }
            return aggregateRoot.Relationships.MapToProductsRelationshipsDtoList(_mapper);
        }
    }
}