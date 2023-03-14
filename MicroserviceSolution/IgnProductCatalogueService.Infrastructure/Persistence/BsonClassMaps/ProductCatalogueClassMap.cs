using IgnProductCatalogueService.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Infrastructure;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.MongoDb.BsonClassMap", Version = "1.0")]

namespace IgnProductCatalogueService.Infrastructure.Persistence.BsonClassMaps
{
    public class ProductCatalogueClassMap : IMongoDbFluentConfiguration
    {
        public void Configure()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(ProductCatalogue)))
            {
                return;
            }
            BsonClassMap.RegisterClassMap<ProductCatalogue>(
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