using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Models;

namespace ProductManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddProduct(Product product)
        {
            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be grater than 0");
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteProduct(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<Product?> GetProductById(int id)
        {
           return await _context.Products.FindAsync(id) ;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
