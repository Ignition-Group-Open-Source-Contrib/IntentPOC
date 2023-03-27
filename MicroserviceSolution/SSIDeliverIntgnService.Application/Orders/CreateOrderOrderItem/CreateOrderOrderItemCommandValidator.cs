using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.CreateOrderOrderItem
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateOrderOrderItemCommandValidator : AbstractValidator<CreateOrderOrderItemCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateOrderOrderItemCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.OrderId)
                .NotNull();

            RuleFor(v => v.ItemEscalation)
                .NotNull();

        }
    }
}