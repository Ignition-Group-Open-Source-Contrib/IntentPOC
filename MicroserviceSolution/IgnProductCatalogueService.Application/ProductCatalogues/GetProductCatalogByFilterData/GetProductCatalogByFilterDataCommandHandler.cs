using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IgnitionGroup.Marketic.MongoDB;
using IgnProductCatalogueService.Application.Helper;
using IgnProductCatalogueService.Domain.Entities;
using IgnProductCatalogueService.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoDB.Driver;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogByFilterData
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductCatalogByFilterDataCommandHandler : IRequestHandler<GetProductCatalogByFilterDataCommand, List<ProductCatalogueDto>>
    {
        private readonly IMongoRepository<ProductCatalogue> _productCatalogRepository;
        private readonly IProductCatalogueRepository _productCatalogueRepository;
        private readonly IMapper _mapper;

        [IntentManaged(Mode.Ignore)]
        public GetProductCatalogByFilterDataCommandHandler(IMongoRepository<ProductCatalogue> productCatalogRepository
            , IMapper mapper
            , IProductCatalogueRepository productCatalogueRepository)
        {
            _productCatalogRepository = productCatalogRepository;
            _mapper = mapper;
            _productCatalogueRepository = productCatalogueRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<List<ProductCatalogueDto>> Handle(GetProductCatalogByFilterDataCommand request, CancellationToken cancellationToken)
        {
            var query = new MongoDBQueryBuilder<ProductCatalogue>();
            var queryFilter = query.CreateFilter(request.Request.Filters);

            try
            {
                //this is mongodb query in which we can add more mongo function like .Project(), .Unwind() etc..
                var resultData = await _productCatalogueRepository.Collection.Aggregate().Match(queryFilter).ToListAsync();
                return resultData.MapToProductCatalogueDtoList(_mapper);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}