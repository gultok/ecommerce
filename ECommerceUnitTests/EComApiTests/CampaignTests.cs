using ECommerceApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceUnitTests.EComApiTests
{
    public class CampaignTests
    {
        private readonly HttpClient _client;
        public CampaignTests()
        {
            var testServer = new TestServer(new WebHostBuilder()
                                           .UseStartup<Startup>()
                                           .UseEnvironment("Development"));
            _client = testServer.CreateClient();
        }

        [Theory]
        [InlineData("/campaign/get-campaign-info", HttpStatusCode.NotFound)]
        public async Task Return_Not_Found_Error_Without_CampaignName(string url, HttpStatusCode expectedStatusCode)
        {
            var response = await _client.GetAsync(url);
            var actualStatusCode = response.StatusCode;
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/campaign/get-campaign-info", "C1", HttpStatusCode.OK, "Campaign not found: C1")]
        public async Task Return_OK_And_Not_Found_Campaign(string url, string campaignName, HttpStatusCode expectedStatusCode, string expectedResult)
        {
            var response = await _client.GetAsync($"{url}/{campaignName}");
            var actualStatusCode = response.StatusCode;
            var actualResponse = response.Content.ReadAsStringAsync().Result;
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(expectedResult, actualResponse);
        }

        //call create methods for success and error scenarios
        //[Theory]
        //[InlineData("/campaign/create-campaign", )]
        //public async Task Return()
        //{

        //}

        //call get campaign name after success created 
        //success result and ok get campaign
        //var expectedResult = $"Campaign {campaignName} info;";

    }
}
