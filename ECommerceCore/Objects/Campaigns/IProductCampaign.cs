namespace ECommerceCore.Objects.Campaigns
{
    public interface IProductCampaign : ICampaign
    {
        string ProductCode { get; set; }
        bool CheckProduct(string productCode);
    }
}
