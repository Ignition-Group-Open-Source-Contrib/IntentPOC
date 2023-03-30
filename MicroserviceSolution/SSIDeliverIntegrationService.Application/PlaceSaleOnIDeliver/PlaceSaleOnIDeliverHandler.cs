using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntegrationService.Application.ViewModels;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.PlaceSaleOnIDeliver
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PlaceSaleOnIDeliverHandler : IRequestHandler<PlaceSaleOnIDeliver>
    {
        private 
        [IntentManaged(Mode.Ignore)]
        public PlaceSaleOnIDeliverHandler()
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<Unit> Handle(PlaceSaleOnIDeliver request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Your implementation here...");
        }

        private async Task<(CreateUpdateSaleOrderRequestModel, string)> GetSSOrderDetails(int orderId, List<int> orderItemIds)
        {

        }
    }
}