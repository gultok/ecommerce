using System;

namespace ECommerceCore
{
    public interface IProduct
    {
        public Guid Id { get; set; }
        double? CampaignPrice { get; set; }
        string Code { get; set; }
        double? Price { get; set; }
        double? Stock { get; set; }
        string GetProductInfo();
    }
}