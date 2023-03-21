using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.CreateProductsAttributes
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductsAttributesCommandValidator : AbstractValidator<CreateProductsAttributesCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateProductsAttributesCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Name)
                .NotNull();

            RuleFor(v => v.Type)
                .NotNull();

            RuleFor(v => v.Value)
                .NotNull();

        }
    }
}