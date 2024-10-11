using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.MongoSettings
{
    public class MongoDContext<TEntity>: IMongoDbContext<TEntity>
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDContext(IOptions<MongoDbSettings> settings)
        {
            _mongoClient = new MongoClient(settings.Value.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<TEntity> GetCollection(string collectionName = null)
        {
            return _mongoDatabase.GetCollection<TEntity>(string.IsNullOrEmpty(collectionName) ? FormatTypeName : collectionName);
        }

        private static string FormatTypeName => typeof(TEntity).Name.ToLowerInvariant();
    }
}
