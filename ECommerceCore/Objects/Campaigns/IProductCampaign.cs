namespace ECommerceCore.Objects.Campaigns
{
    public interface IProductCampaign : ICampaign
    {
        public string ProductCode { get; set; }
        public bool CheckProduct(string productCode);
    }
}
