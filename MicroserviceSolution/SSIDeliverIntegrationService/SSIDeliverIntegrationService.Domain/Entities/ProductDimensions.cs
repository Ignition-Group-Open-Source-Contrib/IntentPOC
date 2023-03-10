using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class ProductDimensions
    {
        public int ProductDimensionsId { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public decimal? Breadth { get; set; }

        public decimal? Length { get; set; }

        public ICollection<int> ProductId { get; set; } = new List<int>();
    }
}