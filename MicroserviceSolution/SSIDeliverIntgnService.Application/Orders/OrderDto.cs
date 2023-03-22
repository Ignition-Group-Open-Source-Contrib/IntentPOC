using System;
using System.Collections.Generic;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using SSIDeliverIntgnService.Application.Common.Mappings;
using SSIDeliverIntgnService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders
{

    public class OrderDto : IMapFrom<Order>
    {
        public OrderDto()
        {
        }

        public static OrderDto Create(
            string id,
            DateTime orderDate,
            int dialerAgentId,
            int? period,
            string? comments,
            string? basketReference,
            int escalationIndex,
            int? debitOrderDay,
            int customerId,
            bool? billingIsPaid,
            DateTime? billingDate,
            int? mSOrdermasterId,
            int? eMOrdermasterId,
            decimal? affordability,
            bool? ctflag,
            int? orderOdooId)
        {
            return new OrderDto
            {
                Id = id,
                OrderDate = orderDate,
                DialerAgentId = dialerAgentId,
                Period = period,
                Comments = comments,
                BasketReference = basketReference,
                EscalationIndex = escalationIndex,
                DebitOrderDay = debitOrderDay,
                CustomerId = customerId,
                BillingIsPaid = billingIsPaid,
                BillingDate = billingDate,
                MSOrdermasterId = mSOrdermasterId,
                EMOrdermasterId = eMOrdermasterId,
                Affordability = affordability,
                Ctflag = ctflag,
                OrderOdooId = orderOdooId,
            };
        }

        public string Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int DialerAgentId { get; set; }

        public int? Period { get; set; }

        public string? Comments { get; set; }

        public string? BasketReference { get; set; }

        public int EscalationIndex { get; set; }

        public int? DebitOrderDay { get; set; }

        public int CustomerId { get; set; }

        public bool? BillingIsPaid { get; set; }

        public DateTime? BillingDate { get; set; }

        public int? MSOrdermasterId { get; set; }

        public int? EMOrdermasterId { get; set; }

        public decimal? Affordability { get; set; }

        public bool? Ctflag { get; set; }

        public int? OrderOdooId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>();
        }
    }
}