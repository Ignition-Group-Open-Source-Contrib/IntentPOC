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
    public class Deal : IHasDomainEvent
    {
        public int DealID { get; set; }

        public string Title { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public int Hot { get; set; }

        public int Available { get; set; }

        public int? TariffID { get; set; }

        public int? MsId { get; set; }

        public int? EMId { get; set; }

        public decimal GP { get; set; }

        public decimal Cost { get; set; }

        public string? ExternalReference { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public int Multiple { get; set; }

        public string? RatePlan { get; set; }

        public int? MSDealID { get; set; }

        public int? EMDealID { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool? IsInsurable { get; set; }

        public int? JBillingDealId { get; set; }

        public int? HandsetUID { get; set; }

        public int? CreditTabUID { get; set; }

        public bool IsBundle { get; set; }

        public int? ThirdPartyCampaignId { get; set; }

        public bool? IsFreemium { get; set; }

        public int? TrialPeriod { get; set; }

        public DateTime SysStartTime { get; set; }

        public DateTime SysEndTime { get; set; }

        public bool? CancelIndividualOrder { get; set; }

        public bool? RequiresUpfrontPayment { get; set; }

        public bool? SimOnly { get; set; }

        public virtual Tariff? Tariff { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}