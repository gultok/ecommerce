using ECommerceService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceService
{
    public class Campaign
    {
        public Campaign() { }
        public Campaign(string _campaignName, string _productCode, int _duration, double _limit, double _targetSalesCount)
        {
            CampaignName = _campaignName;
            ProductCode = _productCode;
            Duration = _duration;
            Limit = _limit;
            TargetSalesCount = _targetSalesCount;
        }
        public string CampaignName { get; set; }
        public string ProductCode { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; }
        public double Limit { get; set; }
        public double TargetSalesCount { get; set; }
        public E_CampaignStatus Status { get; set; }
        public double TotalSalesCount { get; set; }
        public double Turnover { get; set; }
        public decimal AverageItemPrice { get; set; }
        public double Percentage { get; set; }
        public E_ManipulationType ManipulationType { get; set; }
        public double ManipulationValue { get; set; }
        public static string CreateCampaign(string campaignName, string productCode, int duration, double limit, double targetSalesCount)
        {
            Campaign campaign = new Campaign(campaignName, productCode, duration, limit, targetSalesCount);
            campaign.ManipulationType = E_ManipulationType.Increase;
            Pool.Campaigns.Add(campaign);

            campaign = Pool.Campaigns.FirstOrDefault(c => c.CampaignName.ToLower() == campaignName.ToLower());
            return $"Campaign created; name {campaign.CampaignName}, product {campaign.ProductCode}, duration {campaign.Duration},limit {campaign.Limit}, target sales count {campaign.TargetSalesCount}";
        }
        public static string GetCampaignInfo(string campaignName)
        {
            // get campaign 
            Campaign campaign = Pool.Campaigns.FirstOrDefault(c => c.CampaignName.ToLower() == campaignName.ToLower());
            if (campaign != null)
            {
                if (Time.CurrentTime > campaign.StartTime.Add(new TimeSpan(campaign.Duration, 0, 0)))
                {
                    campaign.Status = E_CampaignStatus.Ended;
                }
                return $"Campaign {campaign.CampaignName} info; Status {campaign.Status.ToString()}, Target Sales {campaign.TargetSalesCount},Total Sales {campaign.TotalSalesCount}, Turnover {campaign.Turnover}, Average Item Price {campaign.AverageItemPrice}";
            }
            return $"Campaign not found: {campaignName}";
        }
        public static List<Campaign> GetCampaignsByProductCode(string productCode)
        {
            return Pool.Campaigns
                .Where(c => c.ProductCode.ToLower() == productCode
                            && c.Status == E_CampaignStatus.Active
                            && Time.CurrentTime <= c.StartTime.Add(new TimeSpan(c.Duration, 0, 0)))
                .ToList();
        }
    }
}