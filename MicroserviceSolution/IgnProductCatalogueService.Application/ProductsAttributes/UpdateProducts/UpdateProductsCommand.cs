using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.UpdateProducts
{
    public class UpdateProductsCommand : IRequest, ICommand
    {
        public Guid Id { get; set; }

        public string Sku { get; set; }

        public string? Label { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public List<UpdateProductsAttributesDto> Attributes { get; set; }

        public List<UpdateProductsRelationshipsDto> Relationships { get; set; }

    }
}