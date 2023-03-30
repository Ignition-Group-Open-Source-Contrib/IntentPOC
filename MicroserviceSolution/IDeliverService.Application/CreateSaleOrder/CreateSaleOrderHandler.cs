using System;
using System.Threading;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using IDeliverService.Application.ThirdPartyServices;
using IDeliverService.Application.ViewModels;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IDeliverService.Application.CreateSaleOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateSaleOrderHandler : IRequestHandler<CreateSaleOrder, CreateUpdateSaleOrderResponseModel>
    {
        private readonly IIDeliverApi _iDeliverApi;

        [IntentManaged(Mode.Ignore)]
        public CreateSaleOrderHandler(IIDeliverApi iDeliverApi)
        {
            _iDeliverApi = iDeliverApi;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<CreateUpdateSaleOrderResponseModel> Handle(CreateSaleOrder request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Token))
                {
                    throw new ApiException("IDeliver Service Create Sale Order invalid token", 400);
                }

                var response = await _iDeliverApi.CreateSaleOrder(request.Token, request.RequestModel);
                var result = response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponseModel>(result.Result);
                    throw new ApiException(errorResponse?.Message, 400);
                }

                var saleOrderResult = JsonConvert.DeserializeObject<CreateUpdateSaleOrderResponseModel>(result.Result);
                if (saleOrderResult == null)
                {
                    throw new ApiException("Data not found after creating sale order", 400);
                }

                return saleOrderResult;
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