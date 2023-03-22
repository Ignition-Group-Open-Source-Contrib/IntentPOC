using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntgnService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class IDeliverOrderInfo
    {
        private Guid? _id;
        public Guid Id
        {
            get => _id ??= Guid.NewGuid();
            set => _id = value;
        }

        public int? IDeliverOrderStatusDetailId { get; set; }

        public int? CreatedByUSerId { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public int CourierId { get; set; }

        public virtual Order Order { get; set; }
    }
}