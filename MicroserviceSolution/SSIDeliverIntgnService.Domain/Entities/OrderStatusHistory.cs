using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntgnService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderStatusHistory
    {
        private Guid? _id;
        public Guid Id
        {
            get => _id ??= Guid.NewGuid();
            set => _id = value;
        }

        public DateTime Occured { get; set; }

        public string Annotation { get; set; }

        public int? CancelStatusDetailId { get; set; }

        public int? EMOrderStatusHistoryId { get; set; }

        public int? MSOrderStatusHistoryId { get; set; }

        public int OrderStatusDetailId { get; set; }

        public int EmailCommSentStatusId { get; set; }

        public int SmscommsSentStatusId { get; set; }
    }
}