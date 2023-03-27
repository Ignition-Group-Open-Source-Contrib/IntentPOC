using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using SSIDeliverIntgnService.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest, ICommand
    {
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

        public List<UpdateOrderOrderItemDto> OrderItems { get; set; }

        public UpdateOrderIDeliverOrderInfoDto IDeliverOrderInfo { get; set; }

    }
}