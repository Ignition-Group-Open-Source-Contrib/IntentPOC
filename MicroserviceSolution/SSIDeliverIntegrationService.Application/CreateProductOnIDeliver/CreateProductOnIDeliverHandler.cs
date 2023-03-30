using System;
using System.Threading;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.Extensions.Configuration;
using SSIDeliverIntegrationService.Application.Common.BusinessLogic;
using SSIDeliverIntegrationService.Application.IDeliverService;
using SSIDeliverIntegrationService.Application.ViewModels;
using SSIDeliverIntegrationService.Domain.Entities.Stock;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.CreateProductOnIDeliver
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductOnIDeliverHandler : IRequestHandler<CreateProductOnIDeliver, IDeliverService.CreateProductResponseModel>
    {
        private readonly ISSIDeliverIntegrationFacade _iDeliverIntegrationFacade;
        private readonly IIDeliverClient _iDeliverClient;
        private readonly IConfiguration _configuration;

        [IntentManaged(Mode.Ignore)]
            public CreateProductOnIDeliverHandler(ISSIDeliverIntegrationFacade iDeliverIntegrationFacade,
                IIDeliverClient iDeliverClient,
                IConfiguration configuration)
        {
            _iDeliverIntegrationFacade = iDeliverIntegrationFacade;
            _iDeliverClient = iDeliverClient;
            _configuration = configuration;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<IDeliverService.CreateProductResponseModel> Handle(CreateProductOnIDeliver request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.ProductId <= 0)
                {
                    throw new ApiException($"Error occurred while creating product on ideliver as product id {request.ProductId} is less than zero", 400);
                }

                var (productDetails, errorMessage) = await _iDeliverIntegrationFacade.GetProductDetails(request.ProductId);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new ApiException(errorMessage, 400);
                }
                if (productDetails == null)
                {
                    throw new ApiException($"Create Product On IDeliver product details not found for product id {request.ProductId}", 400);
                }

                var requestModel = new IDeliverService.CreateProductRequestModel
                {
                    Sku = productDetails.Sku,
                    Name = productDetails.Name,
                    Price = productDetails.Price,
                    Width = productDetails.Width,
                    Length = productDetails.Length,
                    Height = productDetails.Height,
                    Weight = productDetails.Weight,
                    Has_serial_numbers = productDetails.Has_serial_numbers,
                    Channel_id = productDetails.Channel_id,
                };

                var result = await _iDeliverClient.CreateProductAsync(_configuration.GetValue<string>("marketic:ideliver:accesstoken"), requestModel);

                if (result.Id <= 0)
                {
                    throw new ApiException($"Error occurred after creating product on ideliver the ideliver product id is less than zero for ss product id {request.ProductId}", 400);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new ApiException($"An unexpected error has occured due to {ex.GetBaseException().Message} , please contact your administrator.", 400);
            }
        }
    }
}