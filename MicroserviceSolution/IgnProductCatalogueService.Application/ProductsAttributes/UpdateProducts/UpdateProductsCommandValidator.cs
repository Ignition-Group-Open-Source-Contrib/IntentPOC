using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.UpdateProducts
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductsCommandValidator : AbstractValidator<UpdateProductsCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateProductsCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Sku)
                .NotNull();

            RuleFor(v => v.Status)
                .NotNull();

            RuleFor(v => v.Attributes)
                .NotNull();

            RuleFor(v => v.Relationships)
                .NotNull();

        }
    }
}