using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogByFilterData
{
    public class GetProductCatalogByFilterDataCommand : IRequest<List<ProductCatalogueDto>>, ICommand
    {
        public SearchQuery Request { get; set; }

    }
}