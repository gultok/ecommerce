using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Models
{
    public class CampaignInput
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [MinLength(2)]
        public string ProductCode { get; set; }
        
        [Range(0, int.MaxValue)]
        public int Duration { get; set; }
        
        [Range(0, double.MaxValue)]
        public double Limit { get; set; }

        [Range(0, int.MaxValue)]
        public int TargetSalesCount { get; set; }
    }
}
