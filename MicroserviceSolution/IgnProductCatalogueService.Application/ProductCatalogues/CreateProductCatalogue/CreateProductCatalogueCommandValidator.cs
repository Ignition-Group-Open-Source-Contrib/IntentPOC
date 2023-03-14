using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.CreateProductCatalogue
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateProductCatalogueCommandValidator : AbstractValidator<CreateProductCatalogueCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public CreateProductCatalogueCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Sku)
                .NotNull();

            RuleFor(v => v.Label)
                .NotNull();

            RuleFor(v => v.Status)
                .NotNull();

            RuleFor(v => v.ParentId)
                .NotNull();

            RuleFor(v => v.Attributes)
                .NotNull();

        }
    }
}