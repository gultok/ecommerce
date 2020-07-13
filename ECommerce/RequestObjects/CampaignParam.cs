namespace ECommerce.ParameterObjects
{
    public class CampaignParam
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public double Limit { get; set; }
        public double TargetSalesCount { get; set; }
    }
}
