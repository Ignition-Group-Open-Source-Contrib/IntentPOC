using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.CreateProductsRelationships
{
    public class CreateProductsRelationshipsCommand : IRequest<Guid>, ICommand
    {
        public Guid ProductsId { get; set; }

        public string ProductId { get; set; }

    }
}