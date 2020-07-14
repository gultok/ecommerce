using ECommerceCore.Objects.Campaigns;
using System.Linq;

namespace ECommerceCore.Managers
{
    public class CampaignManager
    {
        public static string CreateCampaign(string campaignName, string productCode, int duration, double limit, double targetSalesCount)
        {
            var resultMessage = "";
            // campaign type checker 
            if (productCode != null && duration != 0 && limit != 0 && targetSalesCount != 0)
            {
                resultMessage = CampaignFactory.CreateCampaign(campaignName, productCode, duration, limit, targetSalesCount);
            }
            else if (productCode != null && duration != 0 && limit != 0)
            {
                //Todo
                //PDLCampaignFactory.CreateCampaign(campaignName, productCode, duration, limit);
            }
            return resultMessage;
        }
        public static string GetCampaignInfo(string campaignName)
        {
            ICampaign campaign = Pool.Campaigns.FirstOrDefault(c => c.CampaignName.ToLower() == campaignName.ToLower());
            if (campaign != null)
            {
                return campaign.GetCampaignInfo();
            }
            return $"Campaign not found: {campaignName}";
        }
    }
}