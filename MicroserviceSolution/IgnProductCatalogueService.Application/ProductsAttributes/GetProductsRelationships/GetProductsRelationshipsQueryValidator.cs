using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "1.0")]

namespace IgnProductCatalogueService.Application.ProductsAttributes.GetProductsRelationships
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetProductsRelationshipsQueryValidator : AbstractValidator<GetProductsRelationshipsQuery>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public GetProductsRelationshipsQueryValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
        }
    }
}