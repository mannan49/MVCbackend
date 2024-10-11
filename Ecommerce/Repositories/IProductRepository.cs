using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public interface IProductRepository
    {
        Task<string> AddAsync(Entities.Product product);
        Task<Entities.Product> GetAsync(string id);
        Task<IEnumerable<Entities.Product>> GetAllAsync();
        Task<bool> UpdateAsync(string id , Entities.Product product);
    }
}
