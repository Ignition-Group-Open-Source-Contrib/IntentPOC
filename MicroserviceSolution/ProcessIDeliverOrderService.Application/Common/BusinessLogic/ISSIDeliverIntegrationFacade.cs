using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessIDeliverOrderService.Application.Common.BusinessLogic
{
    public interface ISSIDeliverIntegrationFacade
    {
        Task GetIDeliverSalesOrder();
    }
}
