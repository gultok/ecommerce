using System;

namespace ECommerce.Core
{
    public class Product : IProduct
    {
        public Product() { }
        public Product(string _code, int _stock, double _price)
        {
            Id = Guid.NewGuid();
            Code = _code;
            Stock = _stock;
            Price = _price;
            CampaignPrice = _price;
        }
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int? Stock { get; set; }
        public double? Price { get; set; }
        public double? CampaignPrice { get; set; }

        public string GetProductInfo()
        {
            return $"Product {Code} info; price {CampaignPrice}, stock {Stock}";
        }

        public void UpdateStock(int quantity)
        {
            Stock = quantity;
        }
    }
}