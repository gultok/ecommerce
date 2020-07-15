using ECommerce.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpPut("/system/reset-data")]
        public async Task<IActionResult> ResetData()
        {
            Pool.ResetPool();
            return await Task.FromResult(Ok());
        }
    }
}
