using System;

namespace ECommerceCore
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
