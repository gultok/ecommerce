using ECommerce.Api.Models;
using ECommerce.Core.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ECommerceBaseController
    {
        [HttpPost("/orders")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderInput order)
        {
            ValidateModel();
            var message = new OrderManager().CreateOrder(order.ProductCode, order.Quantity);
            return await Task.FromResult(Ok(message));
        }
    }
}
