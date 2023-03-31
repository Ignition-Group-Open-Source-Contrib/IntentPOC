using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Camp
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class IDeliverCampaignChannelMapping : IHasDomainEvent
    {
        public int IDeliverCampaignChannelMappingId { get; set; }

        public int CampaignId { get; set; }

        public int ChannelId { get; set; }

        public bool IsActive { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}