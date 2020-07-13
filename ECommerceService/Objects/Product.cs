using ECommerceService.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ECommerceService
{
    public class Product
    {
        public Product() { }
        public Product(string _code, double _stock, double _price)
        {
            Code = _code;
            Stock = _stock;
            Price = _price;
        }
        public string Code { get; set; }
        public double? Stock { get; set; }
        public double? Price { get; set; }   
        public double? CampaignPrice { get; set; }
        public static string CreateProduct(string productCode, double price, double stock)
        {
            Product product = new Product(productCode, stock, price);
            // create product
            Pool.Products.Add(product);
            //eklenmiş mi
            product = Pool.Products.FirstOrDefault(p => p.Code.ToLower() == productCode.ToLower());
            return $"Product created; code {productCode}, price {price}, stock {stock}";
        }
        public static string GetProductInfo(string productCode, out Product product)
        {
            product = Pool.Products.FirstOrDefault(p => p.Code.ToLower() == productCode.ToLower());            
            productCode = product.Code;
            if (product != null)
            {
                //check campaigns
                List<Campaign> productCampaigns = Pool.Campaigns.Where(c => c.ProductCode.ToLower() == productCode.ToLower() && c.Status == E_CampaignStatus.Active).ToList();
                if (productCampaigns.Count != 0)
                {
                    foreach (var campaign in productCampaigns)
                    {
                        //product.Price *= (1 - (campaign.Percentage / 100));
                        product.CampaignPrice = product.Price * (1 - (campaign.Percentage / 100));
                    }
                    return $"Product {product.Code} info; price {product.CampaignPrice}, stock {product.Stock}";
                }
                else
                {
                    return $"Product {product.Code} info; price {product.Price}, stock {product.Stock}";
                }
            }
            else
                return $"Product not found: {productCode}";
        }
    }
}