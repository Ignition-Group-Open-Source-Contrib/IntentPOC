using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.PlaceSaleOnIDeliver
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PlaceSaleOnIDeliverValidator : AbstractValidator<PlaceSaleOnIDeliver>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public PlaceSaleOnIDeliverValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.OrderItemIds)
                .NotNull();

        }
    }
}