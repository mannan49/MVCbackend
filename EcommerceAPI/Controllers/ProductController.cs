using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Attributes.ExceptionFilters;

namespace EcommerceAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [TypeFilter(typeof(BadRequestExceptionFilter))]
        public async Task<ActionResult> AddAsync([FromBody] ProductModel productModel)
        {
            var Id  = await _productService.AddAsync(productModel);
            return Ok(Id);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(BadRequestExceptionFilter))]
        public async Task<ActionResult> GetAsync(string id)
        {
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            var product = await _productService.GetAsync(id);
            return Ok(product);
        }

        [HttpGet]
        [TypeFilter(typeof(BadRequestExceptionFilter))]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(BadRequestExceptionFilter))]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] ProductModel model)
        {
            var result = await _productService.UpdateAsync(id, model);
            return Ok(result);
        }
    }
}
