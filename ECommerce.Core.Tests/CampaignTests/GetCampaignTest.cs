using ECommerce.Core.Managers;
using Xunit;

namespace ECommerce.Core.Tests.CampaignTests
{
    [Collection("Serialize")]
    public class GetCampaignTest
    {
        [Theory]
        [InlineData("C10", "Campaign C10 info; Status Active, Target Sales 100,Total Sales 5, Turnover 450, Average Item Price 90")]
        [InlineData("C20", "Campaign C20 info; Status Ended, Target Sales 100,Total Sales 0, Turnover 0, Average Item Price 0")]
        public void Get_Campaign_Info_Success(string campaignName, string expectedMessage)
        {
            // Arrange
            Time.ResetTime();
            Pool.ResetPool();
            IProduct product = new Product("P11", 100, 100);
            Pool.Products.Add(product);
            ICampaign campaign = new Campaign("C10", "P11", 5, 30, 100);
            Pool.Campaigns.Add(campaign);

            ICampaign secondCampaign = new Campaign("C20", "P11", 1, 30, 100);
            Pool.Campaigns.Add(secondCampaign);

            Time.IncreaseTime(2);
            new OrderManager().CreateOrder("P11", 5);

            // Act
            var actualMessage = new CampaignManager().GetCampaignInfo(campaignName);

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Theory]
        [InlineData("", "Campaign name can not be null or empty")]
        [InlineData("C11", "Campaign not found: C11")]
        public void Get_Campaign_Info_Fail(string campaignName, string expectedMessage)
        {
            // Act
            var exception = Assert.Throws<ECommerceException>(() => new CampaignManager().GetCampaignInfo(campaignName));

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}