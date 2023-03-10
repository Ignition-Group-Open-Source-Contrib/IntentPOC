using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IDeliverService.Application.ThirdPartyServices;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Newtonsoft.Json;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace IDeliverService.Application.GetSalesChannel
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetSalesChannelHandler : IRequestHandler<GetSalesChannel, List<SaleChannelsResponseModel>>
    {
        private readonly IIDeliverApi _iDeliverApi;

        [IntentManaged(Mode.Ignore)]
        public GetSalesChannelHandler(IIDeliverApi iDeliverApi)
        {
            _iDeliverApi = iDeliverApi;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<List<SaleChannelsResponseModel>> Handle(GetSalesChannel request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _iDeliverApi.SaleChannels(request.Token);
                return JsonConvert.DeserializeObject<List<SaleChannelsResponseModel>>(response);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}