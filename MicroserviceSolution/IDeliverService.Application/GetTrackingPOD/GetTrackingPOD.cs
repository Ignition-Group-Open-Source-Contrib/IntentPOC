using System;
using System.Collections.Generic;
using IDeliverService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace IDeliverService.Application.GetTrackingPOD
{
    public class GetTrackingPOD : IRequest<TrackingPODResponseModel>, IQuery
    {
        public int Id { get; set; }

        public string Token { get; set; }

    }
}