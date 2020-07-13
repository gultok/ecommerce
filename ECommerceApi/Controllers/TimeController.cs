using ECommerceCore;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpPost("/time/increase-time/{hours}")]
        public IActionResult IncreaseTime(int hours)
        {
            var message = Time.IncreaseTime(hours);
            return Ok(message);
        }
        [HttpPut("/time/reset-time")]
        public IActionResult ResetTime()
        {
            var message = Time.ResetTime();
            return Ok(message);
        }
    }
}
