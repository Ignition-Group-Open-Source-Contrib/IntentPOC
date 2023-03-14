using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.DeleteProductCatalogue
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class DeleteProductCatalogueCommandValidator : AbstractValidator<DeleteProductCatalogueCommand>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public DeleteProductCatalogueCommandValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Id)
                .NotNull();

        }
    }
}