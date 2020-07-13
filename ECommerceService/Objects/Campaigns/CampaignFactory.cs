using ECommerceService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceService.Objects.Campaigns
{
    public class CampaignFactory
    {
        public static string CreateCampaign(string campaignName, string productCode, int duration, double limit, double targetSalesCount)
        {
            ICampaign campaign = new Campaign(campaignName, productCode, duration, limit, targetSalesCount);
            campaign.ManipulationType = E_ManipulationType.Increase;
            Pool.Campaigns.Add(campaign);

            return $"Campaign created; name {campaignName}, product {productCode}, duration {duration},limit {limit}, target sales count {targetSalesCount}";
        }
    }
}
