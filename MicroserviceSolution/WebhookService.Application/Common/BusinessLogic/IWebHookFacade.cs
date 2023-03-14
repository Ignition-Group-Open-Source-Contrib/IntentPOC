using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebhookService.Application.Common.BusinessLogic
{
    public interface IWebHookFacade
    {
        (IDeliverOrderCallBackAPIRequest, string) ValidateRequest(Dictionary<string, object> request);
    }
}
