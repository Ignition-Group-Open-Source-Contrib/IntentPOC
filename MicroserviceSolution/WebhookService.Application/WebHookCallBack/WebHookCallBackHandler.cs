using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using WebhookService.Application.Common.BusinessLogic;
using WebhookService.Application.Common.Eventing;
using WebhookService.Application.Common.Helper;
using WebhookService.Eventing;
using static Google.Rpc.Context.AttributeContext.Types;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace WebhookService.Application.WebHookCallBack
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class WebHookCallBackHandler : IRequestHandler<WebHookCallBack, string>
    {
        private readonly IWebHookFacade _webhookFacade;
        private readonly IEventBus _eventBus;

        [IntentManaged(Mode.Ignore)]
        public WebHookCallBackHandler(IWebHookFacade webhookFacade, IEventBus eventBus)
        {
            _webhookFacade = webhookFacade;
            _eventBus = eventBus;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<string> Handle(WebHookCallBack request, CancellationToken cancellationToken)
        {
            try
            {

                switch (request.Id)
                {

                    case "idelivercallback":
                        var (callBackRequest, errorMessage) = _webhookFacade.ValidateRequest(request.Request);

                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return errorMessage;
                        }

                        if (callBackRequest == null)
                        {
                            return $"IDeliver call back api request is invalid {request}";
                        }
                        _eventBus.Publish(new IDeliverCallBackEvent { Request = callBackRequest });
                        // _ = daprClient.ProcessStockOrder(callBackRequest);
                        return "Stock order is in process!";


                    default:
                        break;

                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}