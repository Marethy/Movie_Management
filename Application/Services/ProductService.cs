using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task AddProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }
    }
}
