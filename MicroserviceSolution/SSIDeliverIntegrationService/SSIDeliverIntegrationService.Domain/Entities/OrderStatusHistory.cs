using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderStatusHistory
    {
        public int OrderStatusHistoryId { get; set; }

        public DateTime Occured { get; set; }

        public string Annotation { get; set; }

        public int OrderStatusDetailId { get; set; }

        public int? OrderCancelReasonDetailId { get; set; }

        public int? CancelStatusDetailId { get; set; }

        public int EmailCommSentStatusId { get; set; }

        public int SmscommSentStatusId { get; set; }

        public int? UserId { get; set; }

        public int? EmorderStatusHistoryId { get; set; }

        public int? MsorderStatusHistoryId { get; set; }

        public int OrderItemId { get; set; }
    }
}