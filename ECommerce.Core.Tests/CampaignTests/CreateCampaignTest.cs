using ECommerce.Core.Managers;
using Xunit;

namespace ECommerce.Core.Tests.CampaignTests
{
    [Collection("Serialize")]
    public class CreateCampaignTest
    {
        [Theory]
        [InlineData("C2", "P11", 3, 10, 100, "Campaign created; name C2, product P11, duration 3,limit 10, target sales count 100")]
        public void Create_Campaign_Success(string campaignName, string productCode, int duration, double limit, double targetSalesCount, string expectedMessage)
        {
            // Act
            var actualMessage = new CampaignManager().CreateCampaign(campaignName, productCode, duration, limit, targetSalesCount);

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
            Assert.Contains(Pool.Campaigns, p => p.CampaignName.ToLower() == campaignName.ToLower());
        }

        [Theory]
        [InlineData("C3", "P12", 3, 10, 100, "Campaign has already exist C3")]
        [InlineData("", "P1", 3, 10, 100, "Campaign name can not be null or empty")]
        [InlineData("C4", "P", 3, 10, 100, "Product code length must be greater than 2")]
        [InlineData("C5", "P1", -1, 10, 100, "Duration must be greater than 0")]
        [InlineData("C6", "P1", 0, -2, 100, "Limit must be greater than 0")]
        [InlineData("C7", "P1", 1, 10, -100, "Target sales count must be greater than 0")]
        [InlineData("C8", "", 0, 0, 0, "This campaign just amazing :)")]
        public void Create_Campaign_Fail(string campaignName, string productCode, int duration, double limit, double targetSalesCount, string expectedMessage)
        {

            // Arrange
            ICampaign campaign = new Campaign(campaignName, productCode, 2, 10, 100);
            Pool.Campaigns.Add(campaign);

            // Act 
            var exception = Assert.Throws<ECommerceException>(() => new CampaignManager().CreateCampaign(campaignName, productCode, duration, limit, targetSalesCount));

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}