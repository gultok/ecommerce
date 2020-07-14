﻿using ECommerceApi.Inputs;
using ECommerceCore;
using ECommerceCore.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("/product/create-product")]
        public IActionResult CreateProduct([FromBody] ProductInput product)
        {
            //product validation
            if (string.IsNullOrEmpty(product.ProductCode) || string.IsNullOrWhiteSpace(product.ProductCode))
                return BadRequest("product code can not be null");
            var message = ProductHandler.CreateProduct(product.ProductCode, product.Price, product.Stock);
            return Ok(message);
        }
        [HttpGet("/product/get-product-info/{productCode}")]
        public IActionResult GetProductInfo(string productCode)
        {
            var message = ProductHandler.GetProductInfo(productCode);
            return Ok(message);
        }
    }
}