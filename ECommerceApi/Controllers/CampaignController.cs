using ECommerceApi.Inputs;
using ECommerceService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        [HttpPost("/campaign/createCampaign")]
        public IActionResult CreateCampaign([FromBody] CampaignInput campaign)
        {
            var message = Campaign.CreateCampaign(campaign.name, campaign.productCode, campaign.duration, campaign.limit, campaign.targetSalesCount);
            return Ok(message);
        }
        [HttpGet("/campaign/getCampaignInfo/{campaignName}")]
        public IActionResult GetCampaignInfo([FromQuery] string campaignName)
        {
            var message = Campaign.GetCampaignInfo(campaignName);
            return Ok();
        }
    }
}
