﻿using ECommerceApi.Models;
using ECommerceCore.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CampaignController : ECommerceBaseController
    {
        [HttpPost("/campaigns")]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignInput campaign)
        {
            ValidateModel();
            var message = new CampaignManager().CreateCampaign(campaign.Name, campaign.ProductCode, campaign.Duration, campaign.Limit, campaign.TargetSalesCount);
            return await Task.FromResult(Ok(message));
        }
        [HttpGet("/campaigns/{campaignName}")]
        public async Task<IActionResult> GetCampaignInfo(string campaignName)
        {
            var message = new CampaignManager().GetCampaignInfo(campaignName);
            return await Task.FromResult(Ok(message));
        }
    }
}
