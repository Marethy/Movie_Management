using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public class IProductRepository 
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int ProductId);
        Task AddProductAsync(Product Product);
        Task UpdateProductAsync(Product Product);
        Task DeleteProductAsync(int ProductId);
    }
}
