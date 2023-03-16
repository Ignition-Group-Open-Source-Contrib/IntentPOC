using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IgnitionGroup.Marketic.MongoDB;
using IgnProductCatalogueService.Application.Helper;
using IgnProductCatalogueService.Application.ProductCatalogues;
using IgnProductCatalogueService.Domain.Entities;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoDB.Driver;
using static Google.Rpc.Context.AttributeContext.Types;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.GetProductCatalogByFilter
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductCatalogByFilterQueryHandler : IRequestHandler<GetProductCatalogByFilterQuery, List<ProductCatalogueDto>>
    {
        private readonly IMongoRepository<ProductCatalogue> _productCatalogRepository;
        private readonly IProductCatalogueRepository _productCatalogueRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductCatalogByFilterQueryHandler(IProductCatalogueRepository productCatalogueRepository
            , IMapper mapper
            , IMongoRepository<ProductCatalogue> productCatalogRepository)
        {
            _productCatalogueRepository = productCatalogueRepository;
            _mapper = mapper;
            _productCatalogRepository = productCatalogRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<List<ProductCatalogueDto>> Handle(GetProductCatalogByFilterQuery request, CancellationToken cancellationToken)
        {
            var query = new MongoDBQueryBuilder<ProductCatalogue>();
            var queryFilter = query.CreateFilter(request.Request.Filters);

            //this is mongodb query in which we can add more mongo function like .Project(), .Unwind() etc..
            var resultData = await _productCatalogRepository.Collection.Aggregate().Match(queryFilter).ToListAsync();
            return resultData.MapToProductCatalogueDtoList(_mapper);
        }
    }
}