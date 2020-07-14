using ECommerceApi.Models;
using ECommerceCore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("/products")]
        public IActionResult CreateProduct([FromBody] ProductInput product)
        {
            //product validation
            if (string.IsNullOrEmpty(product.ProductCode) || string.IsNullOrWhiteSpace(product.ProductCode))
                return BadRequest("product code can not be null");
            var message = ProductManager.CreateProduct(product.ProductCode, product.Price, product.Stock);
            return Ok(message);
        }
        [HttpGet("/products/{productCode}")]
        public IActionResult GetProductInfo(string productCode)
        {
            var message = ProductManager.GetProductInfo(productCode);
            return Ok(message);
        }
    }
}