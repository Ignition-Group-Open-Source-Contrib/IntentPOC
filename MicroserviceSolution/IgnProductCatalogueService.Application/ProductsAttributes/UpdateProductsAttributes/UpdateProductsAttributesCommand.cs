using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.UpdateProductsAttributes
{
    public class UpdateProductsAttributesCommand : IRequest, ICommand
    {
        public Guid ProductsId { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string? Value { get; set; }

        public string Label { get; set; }

        public string? Description { get; set; }

        public IEnumerable<string>? Options { get; set; }

    }
}