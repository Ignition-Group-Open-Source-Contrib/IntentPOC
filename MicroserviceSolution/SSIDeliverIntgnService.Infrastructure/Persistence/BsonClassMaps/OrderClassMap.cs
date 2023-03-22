using Intent.RoslynWeaver.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Generators;
using MongoDB.Infrastructure;
using SSIDeliverIntgnService.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MongoDb.BsonClassMap", Version = "1.0")]

namespace SSIDeliverIntgnService.Infrastructure.Persistence.BsonClassMaps
{
    public class OrderClassMap : IMongoDbFluentConfiguration
    {
        public void Configure()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(Order)))
            {
                return;
            }
            BsonClassMap.RegisterClassMap<Order>(
                build =>
                {
                    build.AutoMap();

                    build.MapIdProperty(c => c.Id)
                        .SetIdGenerator(StringObjectIdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.ObjectId));
                });
        }
    }
}