using System.Collections.Generic;

namespace ECommerceCore
{
    public static class Pool
    {
        public static List<IProduct> Products = new List<IProduct>();
        public static List<ICampaign> Campaigns = new List<ICampaign>();
        public static List<Order> Orders = new List<Order>();
        public static void ResetProducts()
        {
            Products = new List<IProduct>();
        }
        public static void ResetCampaigns()
        {
            Campaigns = new List<ICampaign>();
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