using ECommerce.Core.Managers;
using Xunit;

namespace ECommerce.Core.Tests.ProductTests
{
    [Collection("Serialize")]
    public class GetProductTest
    {
        [Theory]
        [InlineData("P8", "Product P8 info; price 100, stock 50")]
        public void Get_Product_Info_Success(string productCode, string expectedMessage)
        {
            // Arrange 
            Time.ResetTime();
            Pool.ResetPool();
            IProduct product = new Product(productCode, 50, 100);
            Pool.Products.Add(product);

            // Act
            var actualMessage = new ProductManager().GetProductInfo(productCode);
            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Theory]
        [InlineData("P9", "Product P9 info; price 95, stock 50")]
        public void Get_Product_Info_Success_With_Campaign_Price(string productCode, string expectedMessage)
        {
            // Arrange 
            Time.ResetTime();
            Pool.ResetPool();
            IProduct product = new Product(productCode, 50, 100);
            Pool.Products.Add(product);

            ICampaign campaign = new Campaign("C1", productCode, 2, 10, 100);
            Pool.Campaigns.Add(campaign);
            Time.IncreaseTime(1);

            // Act
            var actualMessage = new ProductManager().GetProductInfo(productCode);
            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Theory]
        [InlineData("P10", "Product not found: P10")]
        [InlineData("  ", "Product code can not be null or empty")]
        public void Get_Product_Info_Fail(string productCode, string expectedMessage)
        {
            // Act
            var exception = Assert.Throws<ECommerceException>(() => new ProductManager().GetProductInfo(productCode));

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}