using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntegrationService.Application.Common.Interfaces;
using SSIDeliverIntegrationService.Application.ViewModels;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.GetSaleChannels
{
    public class GetSaleChannels : IRequest<List<SaleChannelsResponseModel>>, IQuery
    {
    }
}