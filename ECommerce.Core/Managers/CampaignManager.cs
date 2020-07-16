using ECommerce.Core.Objects.Campaigns;
using System.Linq;
using System.Net;

namespace ECommerce.Core.Managers
{
    public class CampaignManager
    {
        public string CreateCampaign(string campaignName, string productCode, int duration, double limit, double targetSalesCount)
        {
            var resultMessage = "";
            CreateCampaignValidate(campaignName, productCode, duration, limit, targetSalesCount);

            var existingCampaign = Pool.Campaigns.FirstOrDefault(p => p.CampaignName.ToLower() == campaignName.ToLower());
            if (existingCampaign != null)
                throw new ECommerceException($"Campaign has already exist {campaignName}", (int)HttpStatusCode.BadRequest);

            if (productCode != null && duration != 0 && limit != 0 && targetSalesCount != 0)
            {
                resultMessage = new CampaignFactory().CreateCampaign(campaignName, productCode, duration, limit, targetSalesCount);
            }
            // another campaigns 
            return resultMessage;
        }
        public string GetCampaignInfo(string campaignName)
        {
            GetCampaignInfoValidate(campaignName);
            ICampaign campaign = Pool.Campaigns.FirstOrDefault(c => c.CampaignName.ToLower() == campaignName.ToLower());
            if (campaign != null)
            {
                return campaign.GetCampaignInfo();
            }
            throw new ECommerceException($"Campaign not found: {campaignName}", (int)HttpStatusCode.NotFound);
        }
        private void CreateCampaignValidate(string campaignName, string productCode, int duration, double limit, double targetSalesCount)
        {
            if (string.IsNullOrWhiteSpace(campaignName))
                throw new ECommerceException("Campaign name can not be null or empty", (int)HttpStatusCode.BadRequest);
           
            if (!string.IsNullOrWhiteSpace(productCode) && productCode.Length < 2)
            {
                throw new ECommerceException("Product code length must be greater than 2", (int)HttpStatusCode.BadRequest);
            }
            
            if (duration < 0)
                throw new ECommerceException("Duration must be greater than 0", (int)HttpStatusCode.BadRequest);
            
            if (limit < 0)
                throw new ECommerceException("Limit must be greater than 0", (int)HttpStatusCode.BadRequest);
            
            if (targetSalesCount < 0)
                throw new ECommerceException("Target sales count must be greater than 0", (int)HttpStatusCode.BadRequest);
            
            if (string.IsNullOrWhiteSpace(productCode) && duration == 0 && limit == 0 && targetSalesCount == 0)
                throw new ECommerceException("This campaign just amazing :)", (int)HttpStatusCode.BadRequest);
        }
        private void GetCampaignInfoValidate(string campaignName)
        {
            if (string.IsNullOrWhiteSpace(campaignName))
                throw new ECommerceException("Campaign name can not be null or empty", (int)HttpStatusCode.BadRequest);
        }
    }
}