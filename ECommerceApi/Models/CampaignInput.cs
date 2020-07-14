namespace ECommerceApi.Models
{
    public class CampaignInput
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public double Limit { get; set; }
        public double TargetSalesCount { get; set; }
    }
}
