using ECommerce.Core.Enums;
using ECommerce.Core.Objects.Campaigns;
using System;

namespace ECommerce.Core
{
    public class Campaign : IProductDurationLimitTargetSalesCampaign
    {
        public Campaign() { }
        public Campaign(string _campaignName, string _productCode, int _duration, double _limit, double _targetSalesCount)
        {
            Id = Guid.NewGuid();
            CampaignName = _campaignName;
            ProductCode = _productCode;
            Duration = _duration;
            Limit = _limit;
            TargetSalesCount = _targetSalesCount;
            StartTime = Time.CurrentTime;
            EndTime = new TimeSpan(Time.CurrentTime.Hours + Duration, 0, 0);
        }
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public TimeSpan EndTime { get; set; }
        public double Limit { get; set; }
        public double TargetSalesCount { get; set; }
        public double AverageItemPrice { get; set; }
        public string CampaignName { get; set; }
        public ManipulationType ManipulationType { get; set; }
        public double ManipulationValue { get; set; }
        public double Percentage { get; set; }
        public TimeSpan StartTime { get; set; }
        public CampaignStatus Status { get; set; }
        public double TotalSalesCount { get; set; }
        public double Turnover { get; set; }
        public string GetCampaignInfo()
        {
            if (CheckCampaignEnded())
            {
                Status = CampaignStatus.Ended;
            }
            return $"Campaign {CampaignName} info; Status {Status}, Target Sales {TargetSalesCount},Total Sales {TotalSalesCount}, Turnover {Turnover}, Average Item Price {AverageItemPrice}";
        }

        public void ApplyCampaign(IProduct product)
        {
            var percentage = Percentage + (Time.CurrentTime - StartTime).Hours * 5;
            product.CampaignPrice = product.CampaignPrice * (1 - (percentage / 100));
        }

        public bool CheckCampaignEnded()
        {
            return CheckDuration() || CheckPriceManipulationLimit() || CheckTargetSalesCount();
        }

        public bool CheckDuration()
        {
            return Time.CurrentTime > EndTime;
        }

        public bool CheckPriceManipulationLimit()
        {
            var percentage = Percentage + (Time.CurrentTime - StartTime).Hours * 5;
            return percentage > Limit;
        }

        public bool CheckProduct(string productCode)
        {
            return productCode.ToLower() == ProductCode;
        }

        public bool CheckTargetSalesCount()
        {
            return TotalSalesCount == TargetSalesCount;
        }
    }
}