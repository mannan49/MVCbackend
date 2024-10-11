using Ecommerce.MongoSettings;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDbContext<TEntity> _dbContext;
        protected readonly IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(IMongoDbContext<TEntity> context, string collectionName)
        {
            _dbContext = context;
            _dbCollection = _dbContext.GetCollection(collectionName);
        }
    }
}
