using System;
using System.Collections.Generic;
using IDeliverService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace IDeliverService.Application.SalesChannels
{
    public class SalesChannels : IRequest<List<SaleChannelsResponseModel>>, IQuery
    {
        public string Token { get; set; }

    }
}