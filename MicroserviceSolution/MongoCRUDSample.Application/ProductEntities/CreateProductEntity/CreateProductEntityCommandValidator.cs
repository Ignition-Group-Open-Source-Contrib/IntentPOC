using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace MongoCRUDSample.Application.ProductEntities.CreateProductEntity
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductEntityCommandValidator : AbstractValidator<CreateProductEntityCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateProductEntityCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.ProductName)
                .NotNull()
                .MaximumLength(200);

            RuleFor(v => v.Sku)
                .NotNull()
                .MaximumLength(100);

        }
    }
}