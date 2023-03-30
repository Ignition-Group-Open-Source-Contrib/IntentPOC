using System;
using System.Collections.Generic;
using IDeliverService.Application.Common.Interfaces;
using IDeliverService.Application.ViewModels;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IDeliverService.Application.CreateSaleOrder
{
    public class CreateSaleOrder : IRequest<CreateUpdateSaleOrderRequestModel>, ICommand
    {
        public string Token { get; set; }

        public CreateUpdateSaleOrderRequestModel RequestModel { get; set; }

    }
}