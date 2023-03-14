using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductCatalogues.GetProductCatalogueById
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductCatalogueByIdQueryValidator : AbstractValidator<GetProductCatalogueByIdQuery>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public GetProductCatalogueByIdQueryValidator()
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