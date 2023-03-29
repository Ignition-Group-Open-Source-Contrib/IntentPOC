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
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IDeliverService.Application.UpdateSaleOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateSaleOrderHandler : IRequestHandler<UpdateSaleOrder, CreateUpdateSaleOrderResponseModel>
    {
        private readonly IIDeliverApi _iDeliverApi;

        [IntentManaged(Mode.Ignore)]
        public UpdateSaleOrderHandler(IIDeliverApi iDeliverApi)
        {
            _iDeliverApi = iDeliverApi;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<CreateUpdateSaleOrderResponseModel> Handle(UpdateSaleOrder request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Token))
                {
                    throw new ApiException("IDeliver service update sales order invalid token", 400);
                }

                var response = await _iDeliverApi.UpdateSaleOrder(request.Token, request.Id, request.Request);
                var result = JsonConvert.DeserializeObject<CreateUpdateSaleOrderResponseModel>(response);
                if (result == null)
                {
                    throw new ApiException("Data not found after updating sale order", 400);
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