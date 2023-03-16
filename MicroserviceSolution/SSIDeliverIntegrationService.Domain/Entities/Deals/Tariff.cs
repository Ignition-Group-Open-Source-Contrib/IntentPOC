using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Deals
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class Tariff : IHasDomainEvent
    {
        public int TariffID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Duration { get; set; }

        public decimal Price { get; set; }

        public decimal? PayIn { get; set; }

        public int? MonthsFree { get; set; }

        public int? Active { get; set; }

        public byte[]? Picture { get; set; }

        public string? TopBillingProductName { get; set; }

        public decimal? Limit { get; set; }

        public int? MsTariffId { get; set; }

        public string? RatePlan { get; set; }

        public string? ExternalReference { get; set; }

        public DateTime SysStartTime { get; set; }

        public DateTime SysEndTime { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}