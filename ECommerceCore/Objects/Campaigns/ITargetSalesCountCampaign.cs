namespace ECommerceCore.Objects.Campaigns
{
    public interface ITargetSalesCountCampaign : ICampaign
    {
        double TargetSalesCount { get; set; }
        bool CheckTargetSalesCount();
    }
}
