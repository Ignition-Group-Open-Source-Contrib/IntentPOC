using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntegrationService.Domain.Common;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace SSIDeliverIntegrationService.Domain.Entities.Cust
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class CustomerAddress : IHasDomainEvent
    {
        public int CustomerAddressId { get; set; }

        public int CustomerId { get; set; }

        public int AddressTypeId { get; set; }

        public int? ResIdenceTypeId { get; set; }

        public int CityId { get; set; }

        public string? Company { get; set; }

        public int ProvinceId { get; set; }

        public string? Notes { get; set; }

        public DateTime DateAdded { get; set; }

        public string? Suburb { get; set; }

        public string? StreetName { get; set; }

        public string? StreetNum { get; set; }

        public string? Building { get; set; }

        public string PostCode { get; set; }

        public DateTime? DateAtAddress { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public int? MsCustomerAddressID { get; set; }

        public int? EMCustomerAddressID { get; set; }

        public int? CustomerAddressOdooId { get; set; }

        public string? Number { get; set; }

        public string? Department { get; set; }

        public string? FloorNo { get; set; }

        public string? NearByLandmark { get; set; }

        public int? DeliveredTo { get; set; }

        public string? LatLong { get; set; }

        public virtual Customer Customer { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}