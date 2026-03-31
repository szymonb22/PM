using ProductManagement.Models;

namespace ProductManagement.Services
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int id);
        Task<Product?> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task UpdateProduct(Product product);
    }
}
