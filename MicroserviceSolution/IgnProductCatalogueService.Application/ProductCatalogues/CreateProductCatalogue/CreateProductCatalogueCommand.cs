using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.CreateProductCatalogue
{
    public class CreateProductCatalogueCommand : IRequest<string>, ICommand
    {
        public string Sku { get; set; }

        public string Label { get; set; }

        public string Status { get; set; }

        public string ParentId { get; set; }

        public Dictionary<string, object> Attributes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}