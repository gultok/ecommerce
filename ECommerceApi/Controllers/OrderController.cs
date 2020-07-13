﻿using ECommerceApi.Inputs;
using ECommerceService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("/order/createOrder")]
        public IActionResult CreateOrder([FromBody] OrderInput order)
        {
            var message = Order.CreateOrder(order.productCode, order.quantity);
            return Ok(message);
        }
    }
}
