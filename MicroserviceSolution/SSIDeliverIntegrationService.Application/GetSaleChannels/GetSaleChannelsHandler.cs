using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SSIDeliverIntegrationService.Application.IDeliverService;
using SSIDeliverIntegrationService.Application.ViewModels;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.GetSaleChannels
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetSaleChannelsHandler : IRequestHandler<GetSaleChannels, List<ViewModels.SaleChannelsResponseModel>>
    {
        private readonly IIDeliverClient _iDeliverClient;
        private readonly IConfiguration _configuration;

        [IntentManaged(Mode.Ignore)]
        public GetSaleChannelsHandler(IIDeliverClient iDeliverClient, IConfiguration configuration)
        {
            _iDeliverClient = iDeliverClient;
            _configuration = configuration;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<List<ViewModels.SaleChannelsResponseModel>> Handle(GetSaleChannels request, CancellationToken cancellationToken)
        {
            var response = await iDeliverClient.SalesChannelsAsync(configuration.GetValue<string>("marketic:ideliver:accesstoken"), cancellationToken);
            var result = JsonConvert.DeserializeObject<List<ViewModels.SaleChannelsResponseModel>>(response.ToString());
            return result;
        }
    }
}