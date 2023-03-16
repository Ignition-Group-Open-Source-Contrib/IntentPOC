using System;
using System.Collections.Generic;
using IgnProductCatalogueService.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace IgnProductCatalogueService.Application.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>, ICommand
    {
        public string AccountId { get; set; }
        public string OrderStatus { get; set; }
        public string CollectionType { get; set; }
        public bool Active { get; set; }
        public string Seller { get; set; }
        public string BankingRef { get; set; }
        public string OfferId { get; set; }
        public string Channel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string OrderId { get; set; }
    }
}