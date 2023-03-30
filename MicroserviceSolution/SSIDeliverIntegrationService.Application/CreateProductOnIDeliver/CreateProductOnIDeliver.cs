using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntegrationService.Application.Common.Interfaces;
using SSIDeliverIntegrationService.Application.ViewModels;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.CreateProductOnIDeliver
{
    public class CreateProductOnIDeliver : IRequest<IDeliverService.CreateProductResponseModel>, ICommand
    {
        public int ProductId { get; set; }

    }
}