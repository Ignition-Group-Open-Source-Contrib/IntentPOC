using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.UpdateProductOnIDeliver
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductOnIDeliverValidator : AbstractValidator<UpdateProductOnIDeliver>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateProductOnIDeliverValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}