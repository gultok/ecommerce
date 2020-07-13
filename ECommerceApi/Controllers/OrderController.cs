using ECommerceApi.Inputs;
using ECommerceCore.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("/order/create-order")]
        public IActionResult CreateOrder([FromBody] OrderInput order)
        {
            var message = OrderHandler.CreateOrder(order.ProductCode, order.Quantity);
            return Ok(message);
        }
    }
}
