using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class Customer : IHasDomainEvent
    {
        public int CustomerId { get; set; }

        public string IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TitleId { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? OldMsId { get; set; }

        public long? OldEmid { get; set; }

        public string FullName { get; set; }

        public string MaidenName { get; set; }

        public int? Dependencies { get; set; }

        public int? Education { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public int? MsCustomerId { get; set; }

        public int? EmcustomerId { get; set; }

        public int IdentificationTypeId { get; set; }

        public int? CustomerOdooId { get; set; }

        public bool? CtFlag { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}