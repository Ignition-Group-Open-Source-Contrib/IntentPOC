using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class Deal
    {
        public int DealId { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int Hot { get; set; }

        public int Available { get; set; }

        public int? SupplierId { get; set; }

        public int? MsId { get; set; }

        public int? Emid { get; set; }

        public decimal Gp { get; set; }

        public decimal Cost { get; set; }

        public int DealType { get; set; }

        public string ExternalReference { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public int Multiple { get; set; }

        public string RatePlan { get; set; }

        public int? MsdealId { get; set; }

        public int? EmdealId { get; set; }

        public int? SaleRuleId { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool? IsInsurable { get; set; }

        public bool? JbillingDealId { get; set; }

        public int? HandsetUid { get; set; }

        public int? CreditTabUid { get; set; }

        public bool IsBundle { get; set; }

        public int? ThirdPartyCampaignId { get; set; }

        public bool? IsFreemium { get; set; }

        public int? TrialPeriod { get; set; }

        public bool? CancelIndividualOrder { get; set; }

        public bool? RequiresUpfrontPayment { get; set; }

        public bool? SimOnly { get; set; }

        public int TariffId { get; set; }
    }
}