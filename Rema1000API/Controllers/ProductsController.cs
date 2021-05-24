using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Rema1000API.Controllers.Requests;
using Rema1000API.Services;

namespace Rema1000API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}/stock")]
        public async Task<bool> TakeProductStock(int id,TakeStockRequest request)
        {
            if (id != request.Product.Id)
            {
                return false;
            }

            var productData = await _productService.GetProduct(id); 

            if (productData.Stock - request.Quantity >= 0)
            {
                productData.Stock -= request.Quantity;
            }

            var result = await _productService.PutProduct(id, productData);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var result = await _productService.PutProduct(id, product);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var result = _productService.PostProduct(product);

            return CreatedAtAction("GetProduct", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
