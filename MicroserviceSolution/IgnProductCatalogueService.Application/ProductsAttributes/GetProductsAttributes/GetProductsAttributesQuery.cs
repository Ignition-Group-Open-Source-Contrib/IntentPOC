using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.GetProductsAttributes
{
    public class GetProductsAttributesQuery : IRequest<List<ProductsAttributesDto>>, IQuery
    {
        public Guid ProductsId { get; set; }

    }
}