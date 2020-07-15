using ECommerceApi.Models;
using ECommerceCore.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ECommerceBaseController
    {
        [HttpPost("/products")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductInput product)
        {
            ValidateModel();
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