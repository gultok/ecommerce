using ECommerceService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpGet("/system/resetData")]
        public IActionResult ResetData()
        {
            Pool.ResetPool();
            return Ok();
        }
    }
}
