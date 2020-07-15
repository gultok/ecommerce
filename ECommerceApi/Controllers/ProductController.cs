using ECommerceApi.Models;
using ECommerceCore.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("/products")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductInput product)
        {
            //product validation
            if (string.IsNullOrEmpty(product.ProductCode) || string.IsNullOrWhiteSpace(product.ProductCode))
                return BadRequest("product code can not be null");
            var message = new ProductManager().CreateProduct(product.ProductCode, product.Price, product.Stock);
            return await Task.FromResult(Ok(message));
        }
        [HttpGet("/products/{productCode}")]
        public async Task<IActionResult> GetProductInfo(string productCode)
        {
            var message = new ProductManager().GetProductInfo(productCode);
            return await Task.FromResult(Ok(message));
        }
    }
}