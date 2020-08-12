using FluentValidation;
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
    public class CampaignInputValidator: AbstractValidator<CampaignInput>
    {
        public CampaignInputValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.ProductCode).MinimumLength(2);
            RuleFor(c => c.Duration).InclusiveBetween(0, int.MaxValue);
            RuleFor(c => c.Limit).InclusiveBetween(0, double.MaxValue);
            RuleFor(c => c.TargetSalesCount).InclusiveBetween(0, int.MaxValue);
        }
    }
}
