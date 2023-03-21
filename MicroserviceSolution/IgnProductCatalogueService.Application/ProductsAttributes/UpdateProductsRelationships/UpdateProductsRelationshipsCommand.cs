using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.UpdateProductsRelationships
{
    public class UpdateProductsRelationshipsCommand : IRequest, ICommand
    {
        public Guid ProductsId { get; set; }

        public Guid Id { get; set; }

        public string ProductId { get; set; }

    }
}