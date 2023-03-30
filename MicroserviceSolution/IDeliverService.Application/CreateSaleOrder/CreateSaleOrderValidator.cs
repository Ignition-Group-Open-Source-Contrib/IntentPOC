using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IDeliverService.Application.CreateSaleOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateSaleOrderValidator : AbstractValidator<CreateSaleOrder>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateSaleOrderValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Token)
                .NotNull();

            RuleFor(v => v.RequestModel)
                .NotNull();

        }
    }
}