using System;

namespace ECommerce.Core.Objects.Campaigns
{
    public interface IDurationCampaign : ICampaign
    {
        int Duration { get; set; }
        TimeSpan EndTime { get; set; }
        bool CheckDuration();
    }
}