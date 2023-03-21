using Intent.RoslynWeaver.Attributes;
using MongoCRUDSample.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Infrastructure;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MongoDb.BsonClassMap", Version = "1.0")]

namespace MongoCRUDSample.Infrastructure.Persistence.BsonClassMaps
{
    public class ProductEntityClassMap : IMongoDbFluentConfiguration
    {
        public void Configure()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(ProductEntity)))
            {
                return;
            }
            BsonClassMap.RegisterClassMap<ProductEntity>(
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