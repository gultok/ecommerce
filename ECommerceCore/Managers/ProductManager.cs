using ECommerceCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceCore.Managers
{
    public class ProductManager
    {
        public string CreateProduct(string productCode, double price, int stock)
        {
            IProduct product = new Product(productCode, stock, price);
            var existingProduct = Pool.Products.FirstOrDefault(p => p.Code.ToLower() == productCode.ToLower());
            if (existingProduct == null)
                Pool.Products.Add(product);
            else
                throw new Exception("product existing");
            return $"Product created; code {productCode}, price {price}, stock {stock}";
        }
        public string GetProductInfo(string productCode)
        {
            IProduct product = Pool.Products.FirstOrDefault(p => p.Code.ToLower() == productCode.ToLower());
            if (product != null)
            {
                productCode = product.Code;
                //check campaigns
                List<ICampaign> productCampaigns = Pool.Campaigns.Where(c => c.Status == CampaignStatus.Active).ToList();
                if (productCampaigns.Count != 0)
                {
                    product.CampaignPrice = product.Price;
                    foreach (var campaign in productCampaigns)
                    {
                        if (!campaign.CheckCampaignEnded())
                            campaign.ApplyCampaign(product);
                    }
                }
                return product.GetProductInfo();
            }
            else
                return $"Product not found: {productCode}";
        }
    }
}
