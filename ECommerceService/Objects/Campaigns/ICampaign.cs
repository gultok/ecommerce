using ECommerceCore.Enums;
using System;

namespace ECommerceCore
{
    public interface ICampaign
    {
        Guid Id { get; set; }
        decimal AverageItemPrice { get; set; }
        string CampaignName { get; set; }
        E_ManipulationType ManipulationType { get; set; }
        double ManipulationValue { get; set; }
        double Percentage { get; set; }
        TimeSpan StartTime { get; set; }
        E_CampaignStatus Status { get; set; }
        double TotalSalesCount { get; set; }
        double Turnover { get; set; }
        bool CheckCampaignEnded();
        void ApplyCampaign(IProduct product);
        string GetCampaignInfo();
    }
}