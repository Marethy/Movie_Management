using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int ProductId);
        Task AddProductAsync(Product Product);
        Task UpdateProductAsync(Product Product);
        Task DeleteProductAsync(int ProductId);
    }
}
