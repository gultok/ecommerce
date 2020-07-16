using ECommerce.Core.Enums;

namespace ECommerce.Core.Objects.Campaigns
{
    public class CampaignFactory
    {
        public string CreateCampaign(string campaignName, string productCode, int duration, double limit, double targetSalesCount)
        {
            ICampaign campaign = new Campaign(campaignName, productCode, duration, limit, targetSalesCount);
            campaign.ManipulationValue = 5;
            campaign.ManipulationType = ManipulationType.Increase;
            Pool.Campaigns.Add(campaign);

            return $"Campaign created; name {campaignName}, product {productCode}, duration {duration},limit {limit}, target sales count {targetSalesCount}";
        }
    }
}