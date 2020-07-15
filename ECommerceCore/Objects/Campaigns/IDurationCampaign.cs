using System;

namespace ECommerceCore.Objects.Campaigns
{
    public interface IDurationCampaign : ICampaign
    {
        int Duration { get; set; }
        TimeSpan EndTime { get; set; }
        bool CheckDuration();
    }
}
