namespace ECommerceService.Objects.Campaigns
{
    public interface ITargetSalesCountCampaign : ICampaign
    {
        public double TargetSalesCount { get; set; }
        public bool CheckTargetSalesCount();
    }
}
