using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IDeliverService.Application.UpdateSaleOrderStatus
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateSaleOrderStatusValidator : AbstractValidator<UpdateSaleOrderStatus>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateSaleOrderStatusValidator()
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