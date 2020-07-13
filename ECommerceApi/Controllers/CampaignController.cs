using ECommerceApi.Inputs;
using ECommerceService;
using ECommerceService.Handlers;
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
            var message = CampaignHandler.CreateCampaign(campaign.name, campaign.productCode, campaign.duration, campaign.limit, campaign.targetSalesCount);
            return Ok(message);
        }
        [HttpGet("/campaign/getCampaignInfo/{campaignName}")]
        public IActionResult GetCampaignInfo(string campaignName)
        {
            var message = CampaignHandler.GetCampaignInfo(campaignName);
            return Ok(message);
        }
    }
}
