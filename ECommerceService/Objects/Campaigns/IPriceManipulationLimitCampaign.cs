namespace ECommerceService.Objects.Campaigns
{
    public interface IPriceManipulationLimitCampaign : ICampaign
    {
        public double Limit { get; set; }
        public bool CheckPriceManipulationLimit();
    }
}