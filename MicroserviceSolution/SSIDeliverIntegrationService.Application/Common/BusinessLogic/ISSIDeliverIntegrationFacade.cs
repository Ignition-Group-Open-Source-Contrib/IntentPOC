using SSIDeliverIntegrationService.Application.ViewModels;
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
        public Task<(bool, string)> ProcessStockOrder(IDeliverOrderCallBackAPIRequest request, CancellationToken cancellationToken);

    }
}
