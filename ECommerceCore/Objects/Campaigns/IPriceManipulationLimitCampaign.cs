namespace ECommerceCore.Objects.Campaigns
{
    public interface IPriceManipulationLimitCampaign : ICampaign
    {
        double Limit { get; set; }
        bool CheckPriceManipulationLimit();
    }
}