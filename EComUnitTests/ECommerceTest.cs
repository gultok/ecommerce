using ECommerce;
using ECommerceCore;
using System;
using Xunit;

namespace ECommerceUnitTests
{
    public class ECommerceTest
    {
        #region Product Tests
        [Theory]
        [InlineData("create_product P1 5 20", "P1")]
        public void CreateProductCommand_Success(string command, string productCode)
        {
            Global.ValidateAndRunCommand(command);
            Assert.Contains(Pool.Products, p => p.Code.ToLower() == productCode.ToLower());
        }

        [Theory]
        [InlineData("create_product P1   5 20")]
        public void CreateProductCommand_Fail(string command)
        {
            var exception = Assert.Throws<Exception>(() => Global.ValidateAndRunCommand(command));
            Assert.Equal("Second parameter must be a decimal", exception.Message);
        }
        #endregion
    }
}
