using ECommerce.Core.Enums;
using System;

namespace ECommerce.Core
{
    public interface ICampaign
    {
        Guid Id { get; set; }
        double AverageItemPrice { get; set; }
        string CampaignName { get; set; }
        ManipulationType ManipulationType { get; set; }
        double ManipulationValue { get; set; }
        double Percentage { get; set; }
        TimeSpan StartTime { get; set; }
        CampaignStatus Status { get; set; }
        double TotalSalesCount { get; set; }
        double Turnover { get; set; }
        bool CheckCampaignEnded();
        void ApplyCampaign(IProduct product);
        string GetCampaignInfo();
    }
}