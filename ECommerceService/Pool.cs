using System.Collections.Generic;

namespace ECommerceService
{
    public static class Pool
    {
        public static List<Product> Products = new List<Product>();
        public static List<Campaign> Campaigns = new List<Campaign>();
        public static List<Order> Orders = new List<Order>();
        public static void ResetProducts()
        {
            Products = new List<Product>();
        }
        public static void ResetCampaigns()
        {
            Campaigns = new List<Campaign>();
        }
        public static void ResetOrders()
        {
            Orders = new List<Order>();
        }
        public static void ResetPool()
        {
            ResetProducts();
            ResetCampaigns();
            ResetOrders();
        }
    }
}