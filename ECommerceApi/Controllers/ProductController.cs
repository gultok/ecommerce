using ECommerceApi.Inputs;
using ECommerceService;
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
            var message = Product.CreateProduct(product.productcode, product.price, product.stock);
            //mesajlar tek tip ve servisten?
            return Ok(message);
        }
        [HttpGet("/product/getProductInfo/{productCode}")]
        public IActionResult GetProductInfo([FromBody] string productCode)
        {
            Product product;
            var message = Product.GetProductInfo(productCode, out product);
            return Ok(message);
        }
    }
}