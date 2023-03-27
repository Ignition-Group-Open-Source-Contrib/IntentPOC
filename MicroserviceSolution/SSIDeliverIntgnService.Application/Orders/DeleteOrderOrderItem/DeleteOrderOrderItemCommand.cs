using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.DeleteOrderOrderItem
{
    public class DeleteOrderOrderItemCommand : IRequest, ICommand
    {
        public string OrderId { get; set; }

        public Guid Id { get; set; }

    }
}