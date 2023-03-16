using IgnitionGroup.Marketic.MongoDB;
using MongoDB.Bson;
using System.Collections.Generic;

namespace IgnProductCatalogueService.Domain.Entities
{
    [BsonCollection("Order")]
    public class OrderEntity : Document<int>
    {
        public string AccountId { get; set; }
        public string Seller { get; set; }
        public string BankingRef { get; set; }
        public string OfferId { get; set; }
        public string Channel { get; set; }
        public string OrderStatus { get; set; }
        public BsonDocument OrderData { get; set; }
        public string CollectionType { get; set; }
        public string PaymentSuccessUrl { get; set; }
        public string PaymentFailureUrl { get; set; }
        public Dictionary<string, string> BillingData { get; set; }

    }
}
