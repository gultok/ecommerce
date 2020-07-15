using ECommerceCore;
using ECommerceCore.Managers;
using Microsoft.VisualBasic;
using Xunit;

namespace ECommerce.Core.Tests.OrderTests
{
    [Collection("Serialize")]
    public class CreateOrderTest
    {
        [Theory]
        [InlineData("P30", 10, "Order created; product P30, quantity 10")]
        public void Create_Order_Success(string productCode, int quantity, string exceptedMessage)
        {
            // Arrange 
            IProduct product = new Product(productCode, quantity, 100);
            Pool.Products.Add(product);

            // Act
            var actualMessage = new OrderManager().CreateOrder(productCode, quantity);

            // Assert
            Assert.Equal(exceptedMessage, actualMessage);
        }

        [Theory]
        [InlineData("P53", 20, "Product P53 saleable stock is 15")]
        [InlineData("P52", 30, "Product not found P52")]
        [InlineData("", 20, "Product code can not be null or empty")]
        [InlineData("P51", -1, "Quantity must be greater than zero")]
        public void Create_Order_Fail(string productCode, int quantity, string exceptedMessage)
        {
            IProduct product = new Product
            {
                Code = "P53",
                Stock = 15,
                Price = 10
            };
            Pool.Products.Add(product);

            // Act
            var exception = Assert.Throws<ECommerceException>(() => new OrderManager().CreateOrder(productCode, quantity));

            // Assert
            Assert.Equal(exceptedMessage, exception.Message);
        }
    }
}