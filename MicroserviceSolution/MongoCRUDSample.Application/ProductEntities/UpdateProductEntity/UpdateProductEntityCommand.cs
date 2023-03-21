using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoCRUDSample.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.UpdateProductEntity
{
    public class UpdateProductEntityCommand : IRequest, ICommand
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public string Sku { get; set; }

        public decimal ProductPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}