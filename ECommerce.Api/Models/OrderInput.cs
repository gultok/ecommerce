using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Models
{
    public class OrderInput
    {
        [Required]
        [MinLength(2)]
        public string ProductCode { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
