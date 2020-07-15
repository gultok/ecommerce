using System;

namespace ECommerce.Core
{
    public class ECommerceException : Exception
    {
        public int StatusCode { get; set; }
        public ECommerceException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}