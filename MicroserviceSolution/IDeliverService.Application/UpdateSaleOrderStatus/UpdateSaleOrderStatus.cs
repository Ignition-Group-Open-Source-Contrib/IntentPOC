using System;
using System.Collections.Generic;
using IDeliverService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IDeliverService.Application.UpdateSaleOrderStatus
{
    public class UpdateSaleOrderStatus : IRequest<GetSaleOrderResponseModel>, ICommand
    {
        public string Token { get; set; }

        public int Id { get; set; }

        public UpdateOrderStatusRequestModel Request { get; set; }

    }
}