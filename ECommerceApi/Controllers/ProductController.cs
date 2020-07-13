using ECommerceApi.Inputs;
using ECommerceCore;
using ECommerceCore.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("/product/create-product")]
        public IActionResult CreateProduct([FromBody] ProductInput product)
        {
            //product validate
            var message = ProductHandler.CreateProduct(product.ProductCode, product.Price, product.Stock);
            //mesajlar tek tip ve servisten?
            return Ok(message);
        }
        [HttpGet("/product/get-product-info/{productCode}")]
        public IActionResult GetProductInfo(string productCode)
        {
            var message = ProductHandler.GetProductInfo(productCode);
            return Ok(message);
        }
    }
}