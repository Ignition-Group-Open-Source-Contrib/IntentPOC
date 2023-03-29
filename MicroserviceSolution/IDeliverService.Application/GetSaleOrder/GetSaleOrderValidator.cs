using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "1.0")]

namespace IDeliverService.Application.GetSaleOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetSaleOrderValidator : AbstractValidator<GetSaleOrder>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public GetSaleOrderValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Token)
                .NotNull();

        }
    }
}