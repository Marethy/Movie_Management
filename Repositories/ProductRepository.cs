using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int ProductId)

        {
            return await _context.Products.FirstOrDefaultAsync(m => m.ProductID == ProductId);
        }

        public async Task AddProductAsync(Product Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product Product)
        {
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int ProductId)
        {
            var Product = await GetProductByIdAsync(ProductId);
            if (Product != null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
