using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.MongoSettings
{
    public interface IMongoDbContext<TEntity>
    {
        IMongoCollection<TEntity> GetCollection(string name = null);
    }
}
