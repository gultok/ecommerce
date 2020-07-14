using ECommerceCore.Enums;
using ECommerceCore.Objects;
using System;
using System.Collections.Generic;

namespace ECommerceCore
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Active;
        }
    }
}
