using ECommerceApi.Inputs;
using ECommerceCore.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("/orders")]
        public IActionResult CreateOrder([FromBody] OrderInput order)
        {
            if (string.IsNullOrEmpty(order.ProductCode) || string.IsNullOrWhiteSpace(order.ProductCode))
                return BadRequest("Product code can not be null");
            if (order.Quantity <= 0)
                return BadRequest("Quantity must be greater than zero");
            var message = OrderHandler.CreateOrder(order.ProductCode, order.Quantity);
            return Ok(message);
        }
    }
}
