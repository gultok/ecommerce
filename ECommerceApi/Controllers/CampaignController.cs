using ECommerceApi.Inputs;
using ECommerceCore.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        [HttpPost("/campaign/create-campaign")]
        public IActionResult CreateCampaign([FromBody] CampaignInput campaign)
        {
            var message = CampaignHandler.CreateCampaign(campaign.Name, campaign.ProductCode, campaign.Duration, campaign.Limit, campaign.TargetSalesCount);
            return Ok(message);
        }
        [HttpGet("/campaign/get-campaign-info/{campaignName}")]
        public IActionResult GetCampaignInfo(string campaignName)
        {
            var message = CampaignHandler.GetCampaignInfo(campaignName);
            return Ok(message);
        }
    }
}
