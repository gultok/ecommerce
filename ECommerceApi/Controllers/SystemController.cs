using ECommerceCore;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpPut("/system/reset-data")]
        public IActionResult ResetData()
        {
            Pool.ResetPool();
            return Ok();
        }
    }
}
