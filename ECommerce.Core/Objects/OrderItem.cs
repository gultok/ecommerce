using System;
using System.Collections.Generic;

namespace ECommerce.Core.Objects
{
    public class OrderItem
    {
        public OrderItem(Guid productId, double productPrice, int quantity, List<Guid> appliedCampaigns)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ProductPrice = productPrice;
            Quantity = quantity;
            AppliedCampaignIdList = appliedCampaigns;
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public List<Guid> AppliedCampaignIdList { get; set; }
    }
}