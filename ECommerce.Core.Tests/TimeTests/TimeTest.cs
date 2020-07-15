using Xunit;

namespace ECommerce.Core.Tests.TimeTests
{
    [Collection("Serialize")]
    public class TimeTest
    {
        [Theory]
        [InlineData(2, "Time is 02:00:00")]
        public void Increase_Time_Success(int hours, string exceptedMessage)
        {
            Time.ResetTime();
            // Act
            var actualMessage = Time.IncreaseTime(hours);

            // Assert
            Assert.Equal(exceptedMessage, actualMessage);
        }

        [Theory]
        [InlineData(-1, "Hours must be greater than zero.")]
        public void Increase_Time_Fail(int hours, string exceptedMessage)
        {
            // Act
            var exception = Assert.Throws<ECommerceException>(() => Time.IncreaseTime(hours));

            // Assert
            Assert.Equal(exceptedMessage, exception.Message);
        }
    }
}