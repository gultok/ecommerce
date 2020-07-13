using ECommerceService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceService
{
    public class Order
    {
        public List<OrderItem> OrderItems { get; set; }
        public static string CreateOrder(string productCode, double quantity)
        {
            Product product;
            Product.GetProductInfo(productCode, out product);
            //product not found?? 

            //order stock control
            if (product.Stock < quantity)
            {
                Console.WriteLine($"Product stock is less than order quantity, continue with saleable quantity (\" {product.Stock}\")? y / n");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    quantity = product.Stock.Value;
                }
                else
                    return "";
            }

            // campaign stock update 
            //it returns random first campaign, it should be change
            Campaign campaign = Pool.Campaigns.FirstOrDefault(c => c.ProductCode.ToLower() == productCode.ToLower() && c.Status == E_CampaignStatus.Active);
            List<OrderItem> orderItems = new List<OrderItem>();
            if (campaign != null)
            {
                double saleableCampaignStock = campaign.TargetSalesCount - campaign.TotalSalesCount;
                if (quantity > saleableCampaignStock)
                {
                    campaign.TotalSalesCount = saleableCampaignStock;
                    OrderItem orderItem = new OrderItem(product.Code, product.CampaignPrice.Value, saleableCampaignStock);
                    orderItems.Add(orderItem);
                    orderItem = new OrderItem(product.Code, product.Price.Value, quantity - saleableCampaignStock);
                    orderItems.Add(orderItem);
                }
                else
                {
                    campaign.TotalSalesCount = quantity;
                    OrderItem orderItem = new OrderItem(product.Code, product.CampaignPrice.Value, quantity);
                    orderItems.Add(orderItem);
                }
            }
            else
            {
                OrderItem orderItem = new OrderItem(product.Code, product.Price.Value, quantity);
                orderItems.Add(orderItem);
            }

            Order order = new Order
            {
                OrderItems = orderItems
            };

            Pool.Orders.Add(order);
            product.Stock -= quantity;
            return $"Order created; product {product.Code}, quantity {quantity}";
        }
    }
    public class OrderItem
    {
        public OrderItem() { }
        public OrderItem(string productCode, double productPrice, double quantity)
        {
            ProductCode = productCode;
            ProductPrice = productPrice;
            Quantity = quantity;
        }
        public string ProductCode { get; set; }
        public double ProductPrice { get; set; }
        public double Quantity { get; set; }
    }
}
