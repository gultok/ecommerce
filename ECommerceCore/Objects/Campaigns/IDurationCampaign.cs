using System;

namespace ECommerceCore.Objects.Campaigns
{
    public interface IDurationCampaign : ICampaign
    {
        int Duration { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool CheckDuration();
    }
}
