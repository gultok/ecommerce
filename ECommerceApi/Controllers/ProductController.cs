using ECommerceApi.Inputs;
using ECommerceService;
using ECommerceService.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("/product/createProduct")]
        public IActionResult CreateProduct([FromBody] ProductInput product)
        {
            //product validate
            var message = ProductHandler.CreateProduct(product.productcode, product.price, product.stock);
            //mesajlar tek tip ve servisten?
            return Ok(message);
        }
        [HttpGet("/product/getProductInfo/{productCode}")]
        public IActionResult GetProductInfo(string productCode)
        {
            var message = ProductHandler.GetProductInfo(productCode);
            return Ok(message);
        }
    }
}