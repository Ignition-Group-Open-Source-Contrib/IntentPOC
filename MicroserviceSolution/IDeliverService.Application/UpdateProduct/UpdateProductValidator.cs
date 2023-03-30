using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IDeliverService.Application.UpdateProduct
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductValidator : AbstractValidator<UpdateProduct>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateProductValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Token)
                .NotNull();

            RuleFor(v => v.Sku)
                .NotNull();

            RuleFor(v => v.RequestModel)
                .NotNull();

        }
    }
}