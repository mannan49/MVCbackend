using AutoMapper;
using Ecommerce.Attributes.Exceptions;
using Ecommerce.Models;
using Ecommerce.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<string> AddAsync(ProductModel productModel)
        {
            var product = _mapper.Map<Entities.Product>(productModel);
            return await _productRepository.AddAsync(product);
        }

        public async Task<ProductModel> GetAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new BadRequestException("Id cannot be null");
                }
                var product = await _productRepository.GetAsync(id);
                if(product == null)
                {
                    throw new BadRequestException("Product not found");
                }
                return _mapper.Map<ProductModel>(product);

            }
            catch (Exception ex)
            {
                throw new BadRequestException("Internal Server Error");
            }
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                if (products == null || !products.Any())
                {
                    throw new BadRequestException("Products not found");
                }
                return products.Select(product => _mapper.Map<ProductModel>(product)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server error", ex);
            }
        }

        public async Task<bool> UpdateAsync(string id, ProductModel productModel)
        {
            try
            {
                // Check if the provided ID is valid
                if (string.IsNullOrEmpty(id))
                {
                    throw new BadRequestException("Id cannot be null or empty.");
                }

                // Retrieve the existing product to check if it exists
                var previousProduct = await _productRepository.GetAsync(id);
                if (previousProduct == null)
                {
                    throw new BadRequestException("Product does not exist.");
                }

                // Map the previous product to the model
                var previousProductModel = _mapper.Map<ProductModel>(previousProduct);

                // Check if the new model is different from the previous one
                if (previousProductModel.Equals(productModel) == true)
                {
                    throw new BadRequestException("No modifications made.");
                }

                // Map the incoming model to the entity
                var product = _mapper.Map<Entities.Product>(productModel);

                // Perform the update
                return await _productRepository.UpdateAsync(id, product);
            }
            catch (BadRequestException)
            {
                throw; // Rethrow known exceptions
            }
            catch (Exception ex)
            {
                // Optionally log the error
                throw new Exception("Internal server error.", ex);
            }
        }
    }
}
