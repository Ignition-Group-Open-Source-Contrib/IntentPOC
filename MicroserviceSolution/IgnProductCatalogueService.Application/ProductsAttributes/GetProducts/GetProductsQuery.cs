using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductsDto>>, IQuery
    {
    }
}