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

namespace IDeliverService.Application.UpdateProduct
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, CreateProductResponseModel>
    {
        private readonly IIDeliverApi _iDeliverApi;

        [IntentManaged(Mode.Ignore)]
        public UpdateProductHandler(IIDeliverApi iDeliverApi)
        {
            _iDeliverApi = iDeliverApi;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<CreateProductResponseModel> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Token))
                {
                    throw new ApiException("IDeliver service update product invalid token", 400);
                }

                var response = await _iDeliverApi.UpdateProduct(request.Token, request.Sku, request.Request);
                var result = response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException($"IDeliver Service Update Product Failed {result.Result}", 400);
                }

                var updateProductResult = JsonConvert.DeserializeObject<CreateProductResponseModel>(result.Result);
                if (updateProductResult == null)
                {
                    throw new ApiException("Data not found after updating product", 400);
                }

                return updateProductResult;
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