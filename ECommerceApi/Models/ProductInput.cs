using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models
{
    public class ProductInput
    {
        [Required]
        [MinLength(2)]
        public string ProductCode { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Stock { get; set; }
    }
}
