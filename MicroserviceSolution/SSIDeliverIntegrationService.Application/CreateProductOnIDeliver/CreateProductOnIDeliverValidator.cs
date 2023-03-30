using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.CreateProductOnIDeliver
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductOnIDeliverValidator : AbstractValidator<CreateProductOnIDeliver>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateProductOnIDeliverValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}