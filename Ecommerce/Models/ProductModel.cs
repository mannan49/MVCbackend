using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; } = 0;
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

    }
}
