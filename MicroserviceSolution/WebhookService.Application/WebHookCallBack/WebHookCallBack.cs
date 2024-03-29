using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using WebhookService.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace WebhookService.Application.WebHookCallBack
{
    public class WebHookCallBack : IRequest<string>, ICommand
    {
        public string Id { get; set; }

        public Dictionary<string, object> Request { get; set; }

    }
}