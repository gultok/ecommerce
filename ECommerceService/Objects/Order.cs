using ECommerceService.Enums;
using ECommerceService.Objects;
using System;
using System.Collections.Generic;

namespace ECommerceService
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public E_OrderStatus Status { get; set; }
        public Order()
        {
            Id = Guid.NewGuid();
            Status = E_OrderStatus.Active;
        }
    }
}
