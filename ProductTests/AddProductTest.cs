using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Models;
using ProductManagement.Services;
using System.Threading.Tasks;

namespace ProductTests
{
    public class AddProductTest
    {

        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;

            return new AppDbContext(options);
        }
        [Fact]
        public async Task AddProductShould_Add()
        {
        
        //// arrange
            var _context = GetDbContext();
            var _service = new ProductService(_context);
            var newProduct = new Product
            {
                Name = "Test",
                Price = 2000.20m,
                CreatedAt = DateTime.Now,
                Quantity = 1,

            };
            
/// act 
          await _service.AddProduct(newProduct);
            /// assert
            var products = await _context.Products.ToListAsync();
            Assert.Single(products);
            Assert.Equal("Test", products[0].Name);
        }

        [Fact] 
        public async Task AddProductShouldNot_AddProductWithBelowZeroPrice()
        {
            var _context = GetDbContext();
            var _service = new ProductService(_context);
            var newProduct = new Product
            {
                Name = "Test",
                Price = -2000.20m,
                CreatedAt = DateTime.Now,
                Quantity = 1,

            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.AddProduct(newProduct));
        }
    }
}
