using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace IgnProductCatalogueService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class ProductCatalogue
    {
        public string Id { get; set; }

        public string Sku { get; set; }

        public string? Label { get; set; }

        public string Status { get; set; }

        public string? ParentId { get; set; }

        public Dictionary<string, string>? Attributes { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Dictionary<string, string>? Relationships { get; set; }
    }
}