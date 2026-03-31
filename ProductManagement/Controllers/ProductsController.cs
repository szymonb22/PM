using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _service.AddProduct(product);
            return Ok(product);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetProductById(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(Product product)
        {
            await _service.UpdateProduct(product);
            return NoContent();
        }
        [HttpDelete("{id}")]        
        
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
            return NoContent();
        }

       
    }
}
