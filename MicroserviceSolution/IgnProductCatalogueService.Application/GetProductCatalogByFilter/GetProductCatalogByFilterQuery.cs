using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using IgnProductCatalogueService.Application.ProductCatalogues;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.GetProductCatalogByFilter
{
    public class GetProductCatalogByFilterQuery : IRequest<List<ProductCatalogueDto>>, IQuery
    {
        public SearchQuery Request { get; set; }

    }
}