using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.UpdateOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateOrderCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Id)
                .NotNull();

            RuleFor(v => v.OrderItems)
                .NotNull();

            RuleFor(v => v.IDeliverOrderInfo)
                .NotNull();

        }
    }
}