using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using Intent.RoslynWeaver.Attributes;
using WebhookService.Application.Common.Helper;
using static Google.Rpc.Context.AttributeContext.Types;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace WebhookService.Application.WebHookCallBack
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class WebHookCallBackValidator : AbstractValidator<WebHookCallBack>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public WebHookCallBackValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Id)
                .NotNull();

            RuleFor(v => v.Request)
                .NotNull();

        }
    }
}