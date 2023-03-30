using System;
using System.Threading;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using IDeliverService.Application.ThirdPartyServices;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IDeliverService.Application.GetTrackingPOD
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetTrackingPODHandler : IRequestHandler<GetTrackingPOD, TrackingPODResponseModel>
    {
        private readonly IIDeliverApi _iDeliverApi;

        [IntentManaged(Mode.Ignore)]
        public GetTrackingPODHandler(IIDeliverApi iDeliverApi)
        {
            _iDeliverApi = iDeliverApi;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<TrackingPODResponseModel> Handle(GetTrackingPOD request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Token))
                {
                    throw new ApiException("IDeliver service get tracking POD invalid token", 400);
                }

                var response = await _iDeliverApi.GetTrackingPOD(request.Token, request.Id);
                var result = JsonConvert.DeserializeObject<TrackingPODResponseModel>(response);
                if (result == null)
                {
                    throw new ApiException("Data not found", 400);
                }

                return result;
            }
            catch (Exception ex)
            {
                if ((Refit.ApiException)ex.InnerException != null)
                {
                    string exMessage = ((Refit.ApiException)ex.InnerException).Content;
                    if (!string.IsNullOrEmpty(exMessage))
                    {
                        var responseMessage = ((JValue)JObject.Parse(exMessage)["message"]).Value;
                        throw new ApiException(responseMessage, 400);
                    }
                }

                throw new ApiException($"An unexpected error has occured due to {ex.GetBaseException().Message} , please contact your administrator.", 400);
            }
        }
    }
}