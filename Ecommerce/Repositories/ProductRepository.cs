using Ecommerce.Constants;
using Ecommerce.MongoSettings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ProductRepository:BaseRepository<Entities.Product>, IProductRepository
    {
        const string COLLECTION_NAME = CollectionNameConstants.PRODUCT;

        public ProductRepository(IMongoDbContext<Entities.Product> context): base(context, COLLECTION_NAME) { }

        public async Task<string> AddAsync(Entities.Product product)
        {
            await _dbCollection.InsertOneAsync(product);
            return product.Id;
        }

        public async Task<Entities.Product> GetAsync(string id)
        {
            var filter = Builders<Entities.Product>.Filter.Eq(product => product.Id , id);
            var product = await _dbCollection.Find(filter).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Entities.Product>> GetAllAsync()
        {
            var products = await _dbCollection.FindAsync(Builders<Entities.Product>.Filter.Empty);
            return await products.ToListAsync();
        }

        public async Task<bool> UpdateAsync(string id, Entities.Product product)
        {
            var builder = Builders<Entities.Product>.Filter;
            var filter = builder.Eq(e => e.Id, product.Id);
            var result = await _dbCollection.ReplaceOneAsync(filter, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
