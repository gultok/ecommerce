using ECommerceCore.Objects.Campaigns;
using System.Linq;
using System.Net;

namespace ECommerceCore.Managers
{
    public class CampaignManager
    {
        public string CreateCampaign(string campaignName, string productCode, int duration, double limit, double targetSalesCount)
        {
            var resultMessage = "";
            // campaign type checker 
            var existingCampaign = Pool.Campaigns.FirstOrDefault(p => p.CampaignName.ToLower() == campaignName.ToLower());
            if (existingCampaign != null)
                throw new ECommerceException($"Campaign has already exist {campaignName}", (int)HttpStatusCode.BadRequest);

            if (productCode != null && duration != 0 && limit != 0 && targetSalesCount != 0)
            {
                resultMessage = new CampaignFactory().CreateCampaign(campaignName, productCode, duration, limit, targetSalesCount);
            }
            else if (productCode != null && duration != 0 && limit != 0)
            {
                //Todo
                //PDLCampaignFactory.CreateCampaign(campaignName, productCode, duration, limit);
            }
            return resultMessage;
        }
        public string GetCampaignInfo(string campaignName)
        {
            ICampaign campaign = Pool.Campaigns.FirstOrDefault(c => c.CampaignName.ToLower() == campaignName.ToLower());
            if (campaign != null)
            {
                return campaign.GetCampaignInfo();
            }
            throw new ECommerceException($"Campaign not found: {campaignName}", (int)HttpStatusCode.NotFound);
        }
    }
}