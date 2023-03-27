using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;
using SSIDeliverIntegrationService.Domain.Entities.Ord;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Cust
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class Customer : IHasDomainEvent
    {
        public int CustomerID { get; set; }

        public string IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long? OldMsId { get; set; }

        public long? OldEMId { get; set; }

        public string FullName { get; set; }

        public string? MaidenName { get; set; }

        public int? Dependencies { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public int? MsCustomerID { get; set; }

        public int? EMCustomerID { get; set; }

        public int IdentificationTypeId { get; set; }

        public bool? _ctFlag { get; set; }

        public int? CustomerOdooId { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<CustomerContact> CustomerContacts { get; set; } = new List<CustomerContact>();

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}