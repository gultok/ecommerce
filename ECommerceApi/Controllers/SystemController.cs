using ECommerceCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
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
