using SSIDeliverIntegrationService.Application.ViewModels;
using SSIDeliverIntegrationService.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSIDeliverIntegrationService.Application.Common.BusinessLogic
{
    public interface ISSIDeliverIntegrationFacade
    {
        public Task<List<int>> GetIDeliverOrderItems(int orderId, List<int> iDeliverProviders, List<int> skipOrderStatus);
        public Task<(bool, string)> ProcessStockOrder(IDeliverOrderCallBackAPIRequest request, CancellationToken cancellationToken);
        public Task UploadPdfFile(UploadPdfViewModel uploadPdfViewModel);
        public Task<bool> VerifyIDeliverOrder(int orderId, List<int> iDeliverProviders);
        public Task<bool> VerifyInValidOrder(int orderId, List<int> iDeliverProviders);
        public Task<bool> VerifyInValidOrderStatus(int orderId, List<int> iDeliverProviders, List<int> skipOrderStatus);
    }
}
