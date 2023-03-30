using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntegrationService.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.PlaceSaleOnIDeliver
{
    public class PlaceSaleOnIDeliver : IRequest, ICommand
    {
        public int OrderId { get; set; }

        public IEnumerable<int> OrderItemIds { get; set; }

    }
}