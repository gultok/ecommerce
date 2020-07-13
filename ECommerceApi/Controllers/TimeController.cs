using ECommerceService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpPut("/time/increaseTime/{hours}")]
        public IActionResult IncreaseTime(int hours)
        {
            var message = Time.IncreaseTime(hours);
            return Ok(message);
        }
        [HttpGet("/time/resetTime")]
        public IActionResult ResetTime()
        {
            var message = Time.ResetTime();
            return Ok(message);
        }
    }
}
