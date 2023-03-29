using System;
using System.Collections.Generic;
using IDeliverService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IDeliverService.Application.UpdateSaleOrder
{
    public class UpdateSaleOrder : IRequest<CreateUpdateSaleOrderResponseModel>, ICommand
    {
        public string Token { get; set; }

        public int Id { get; set; }

        public CreateUpdateSaleOrderRequestModel Request { get; set; }

    }
}