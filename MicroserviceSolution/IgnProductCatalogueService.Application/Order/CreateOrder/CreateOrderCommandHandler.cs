using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using IgnitionGroup.Marketic.MongoDB;
using IgnProductCatalogueService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using MongoDB.Bson;
using Newtonsoft.Json;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "1.0")]

namespace IgnProductCatalogueService.Application.Order.CreateOrder
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        //private readonly IMongoRepository<OrderEntity> _orderRepo;
        [IntentManaged(Mode.Ignore)]
        public CreateOrderCommandHandler()
        {
            //_orderRepo = orderRepo;

        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var orderEntity = new OrderEntity()
                //{
                //    AccountId = request.AccountId,
                //    Seller = request.Seller,
                //    BankingRef = request.BankingRef,
                //    OfferId = request.OfferId,
                //    Channel = request.Channel,
                //    OrderStatus = request.OrderStatus,
                //    CollectionType = request.CollectionType,
                //    OrderData = BsonDocument.Parse(JsonConvert.SerializeObject(new { request.FirstName })),
                //};

                //// here mongo document is created and id will be int
                //await _orderRepo.InsertOneAsync(orderEntity);
                return 0; //orderEntity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}