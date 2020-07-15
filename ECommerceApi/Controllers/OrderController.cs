using ECommerceApi.Models;
using ECommerceCore.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
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
