using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogueById
{
    public class GetProductCatalogueByIdQuery : IRequest<ProductCatalogueDto>, IQuery
    {
        public string Id { get; set; }

    }
}