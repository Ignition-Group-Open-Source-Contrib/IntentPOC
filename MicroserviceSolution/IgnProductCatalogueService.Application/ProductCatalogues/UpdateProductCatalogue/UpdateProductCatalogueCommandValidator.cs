using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.UpdateProductCatalogue
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class UpdateProductCatalogueCommandValidator : AbstractValidator<UpdateProductCatalogueCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public UpdateProductCatalogueCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Id)
                .NotNull();

            RuleFor(v => v.Sku)
                .NotNull();

            RuleFor(v => v.Status)
                .NotNull();

        }
    }
}