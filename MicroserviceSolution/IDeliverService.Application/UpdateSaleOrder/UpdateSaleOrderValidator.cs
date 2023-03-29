using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IDeliverService.Application.UpdateSaleOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateSaleOrderValidator : AbstractValidator<UpdateSaleOrder>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateSaleOrderValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Token)
                .NotNull();

            RuleFor(v => v.Request)
                .NotNull();

        }
    }
}