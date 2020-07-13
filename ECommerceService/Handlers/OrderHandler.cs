using ECommerceService.Enums;
using ECommerceService.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceService.Handlers
{
    public class OrderHandler
    {
        public static string CreateOrder(string productCode, double quantity)
        {
            var product = Pool.Products.FirstOrDefault(p => p.Code.ToLower() == productCode.ToLower());
            //add validation
            if (product == null)
                return $"Product not found {productCode}";
            //order stock control
            if (product.Stock < quantity)
            {
                quantity = product.Stock.Value;
            }

            List<OrderItem> orderItems = new List<OrderItem>();
            List<ICampaign> campaigns = Pool.Campaigns.Where(c => c.Status == E_CampaignStatus.Active).ToList();
            List<Guid> appliedCampaigns = new List<Guid>();
            product.CampaignPrice = product.Price;
            foreach (var campaign in campaigns)
            {
                if (!campaign.CheckCampaignEnded())
                {
                    campaign.ApplyCampaign(product);
                    appliedCampaigns.Add(campaign.Id);
                }
            }

            OrderItem orderItem = new OrderItem(product.Id, product.CampaignPrice.Value, quantity, appliedCampaigns);
            orderItems.Add(orderItem);

            Order order = new Order
            {
                OrderItems = orderItems
            };

            Pool.Orders.Add(order);
            product.Stock -= quantity;
            return $"Order created; product {product.Code}, quantity {quantity}";
        }
    }
}
