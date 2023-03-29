using System;
using System.Collections.Generic;
using IDeliverService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IDeliverService.Application.UpdateProduct
{
    public class UpdateProduct : IRequest<CreateProductResponseModel>, ICommand
    {
        public string Token { get; set; }

        public string Sku { get; set; }

        public UpdateProductRequestModel Request { get; set; }

    }
}