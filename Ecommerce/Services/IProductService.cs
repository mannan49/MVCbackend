using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public interface IProductService
    {
        Task<string> AddAsync(ProductModel productModel);
        Task<ProductModel> GetAsync(string id);
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<bool> UpdateAsync(string id , ProductModel productModel);
    }
}
