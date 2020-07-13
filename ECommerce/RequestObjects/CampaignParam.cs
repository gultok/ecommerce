﻿namespace ECommerce.ParameterObjects
{
    public class CampaignParam
    {
        public string name { get; set; }
        public string productCode { get; set; }
        public int duration { get; set; }
        public double limit { get; set; }
        public double targetSalesCount { get; set; }
    }
}