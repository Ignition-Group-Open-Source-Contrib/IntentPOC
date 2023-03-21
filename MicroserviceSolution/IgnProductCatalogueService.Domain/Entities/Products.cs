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
    public class Products
    {
        public Guid Id { get; set; }

        public string Sku { get; set; }

        public string? Label { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Attributes> Attributes { get; set; } = new List<Attributes>();

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Relationships> Relationships { get; set; } = new List<Relationships>();
    }
}