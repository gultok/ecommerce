using ECommerceCore.Enums;
using ECommerceCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ECommerceCore.Managers
{
    public class OrderManager
    {
        public string CreateOrder(string productCode, int quantity)
        {
            CreateOrderValidate(productCode, quantity);
            var product = Pool.Products.FirstOrDefault(p => p.Code.ToLower() == productCode.ToLower());
            //add validation
            if (product == null)
                throw new ECommerceException($"Product not found {productCode}", (int)HttpStatusCode.NotFound);
            //order stock control
            if (product.Stock < quantity)
            {
                throw new ECommerceException($"Product {product.Code} saleable stock is {product.Stock}", (int)HttpStatusCode.BadRequest);
            }

            List<OrderItem> orderItems = new List<OrderItem>();
            List<ICampaign> campaigns = Pool.Campaigns.Where(c => c.Status == CampaignStatus.Active).ToList();
            List<Guid> appliedCampaigns = new List<Guid>();
            product.CampaignPrice = product.Price;

            foreach (var campaign in campaigns)
            {
                if (!campaign.CheckCampaignEnded())
                {
                    campaign.ApplyCampaign(product);
                    appliedCampaigns.Add(campaign.Id);
                    campaign.TotalSalesCount += quantity;
                    campaign.Turnover += (quantity * product.CampaignPrice.Value);
                    campaign.AverageItemPrice += ((quantity * product.CampaignPrice.Value) / quantity);
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
        private void CreateOrderValidate(string productCode, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productCode))
                throw new ECommerceException("Product code can not be null or empty", (int)HttpStatusCode.BadRequest);
            if (quantity <= 0)
                throw new ECommerceException("Quantity must be greater than zero", (int)HttpStatusCode.BadRequest);
        }
    }
}
