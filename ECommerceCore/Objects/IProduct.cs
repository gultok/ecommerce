﻿using System;

namespace ECommerceCore
{
    public interface IProduct
    {
        Guid Id { get; set; }
        double? CampaignPrice { get; set; }
        string Code { get; set; }
        double? Price { get; set; }
        int? Stock { get; set; }
        string GetProductInfo();
    }
}