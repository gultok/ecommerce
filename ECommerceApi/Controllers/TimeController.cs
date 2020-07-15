using ECommerceCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpPost("/time/increase-time/{hours}")]
        public async Task<IActionResult> IncreaseTime(int hours)
        {
            if (hours <= 0)
                return await Task.FromResult(BadRequest("Hours must be greater than zero"));
            var message = Time.IncreaseTime(hours);
            return await Task.FromResult(Ok(message));
        }
        [HttpPut("/time/reset-time")]
        public async Task<IActionResult> ResetTime()
        {
            var message = Time.ResetTime();
            return await Task.FromResult(Ok(message));
        }
    }
}
