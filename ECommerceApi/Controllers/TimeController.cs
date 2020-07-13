using ECommerceService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpPut("/time/increaseTime/{hours}")]
        public IActionResult IncreaseTime([FromBody] int hours)
        {
            var message = Time.IncreaseTime(hours);
            return Ok(message);
        }
        [HttpGet("/time/resetTime")]
        public IActionResult ResetTime()
        {
            Time.ResetTime();
            return Ok();
        }
    }
}
