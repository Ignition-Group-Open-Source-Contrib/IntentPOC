using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;

namespace WebhookService.Application.Common.BusinessLogic
{
    public interface IWebHookFacade
    {
        (IDeliverRTSCallBackRequest, string) ValidateDeliveryRTSRequest(Dictionary<string, object> request);
        (IDeliverOrderCallBackAPIRequest, string) ValidateRequest(Dictionary<string, object> request);
    }
}
