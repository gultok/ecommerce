using ECommerce.Core.Enums;
using ECommerce.Core.Objects;
using System;
using System.Collections.Generic;

namespace ECommerce.Core
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
        public void CancelOrder()
        {
            Status = OrderStatus.Cancel;
        }
    }
}