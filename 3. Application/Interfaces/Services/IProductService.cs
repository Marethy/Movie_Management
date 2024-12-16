using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int productId);
        Task AddProductAsync(ProductDTO productDto);
        Task UpdateProductAsync(ProductDTO productDto);
        Task DeleteProductAsync(int productId);
    }
}
