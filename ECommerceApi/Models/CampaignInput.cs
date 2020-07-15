using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models
{
    public class CampaignInput
    {
        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        public string ProductCode { get; set; }
        
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }
        
        [Range(0, double.MaxValue)]
        public double Limit { get; set; }

        [Range(1, int.MaxValue)]
        public int TargetSalesCount { get; set; }
    }
}
