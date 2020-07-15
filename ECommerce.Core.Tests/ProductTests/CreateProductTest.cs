using ECommerceCore;
using ECommerceCore.Managers;
using Xunit;

namespace ECommerce.Core.Tests.ProductTests
{
    [Collection("Serialize")]
    public class CreateProductTest
    {
        [Theory]
        [InlineData("P1", 10, 100, "Product created; code P1, price 10, stock 100")]
        [InlineData("P2", 20.2, 200, "Product created; code P2, price 20.2, stock 200")]
        public void Create_Product_Success(string productCode, double price, int stock, string expectedMessage)
        {
            // Act
            var actualMessage = new ProductManager().CreateProduct(productCode, price, stock);
            
            // Assert
            Assert.Equal(actualMessage, expectedMessage);
            Assert.Contains(Pool.Products, p => p.Code.ToLower() == productCode.ToLower());
        }
        
        [Theory]
        [InlineData("P3", 5, 50, "Product has already exist P3")]
        [InlineData("  ", 5, 50, "Product code can not be null or empty")]
        [InlineData("P", 5, 50, "Product code length must greater than 2")]
        [InlineData("P4", -5, 50, "Product price must be greater than 0")]
        [InlineData("P5", 0, 50, "Product price must be greater than 0")]
        [InlineData("P6", 5, -50, "Product stock must be greater than 0")]
        [InlineData("P7", 5, 0, "Product stock must be greater than 0")]
        public void Create_Product_Fail(string productCode, double price, int stock, string expectedMessage)
        {
            // Arrange 
            IProduct product = new Product(productCode, stock, price);
            Pool.Products.Add(product);

            // Act
            var exception = Assert.Throws<ECommerceException>(() => new ProductManager().CreateProduct(productCode, price, stock));
            
            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
