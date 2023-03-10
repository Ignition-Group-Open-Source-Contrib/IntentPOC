using System;
using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "1.0")]

namespace IDeliverService.Application.GetSalesChannel
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetSalesChannelValidator : AbstractValidator<GetSalesChannel>
    {
        [IntentManaged(Mode.Fully, Body = Mode.Ignore, Signature = Mode.Merge)]
        public GetSalesChannelValidator()
        {
            ConfigureValidationRules();
        }

        [IntentManaged(Mode.Fully)]
        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Token)
                .NotNull();

        }
    }
}