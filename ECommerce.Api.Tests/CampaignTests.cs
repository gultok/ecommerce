using ECommerce.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.ApiTests
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
        [InlineData("/campaigns", HttpStatusCode.MethodNotAllowed)]
        public async Task Return_Method_Not_Allowed_Without_CampaignName(string url, HttpStatusCode expectedStatusCode)
        {
            // Act
            var response = await _client.GetAsync(url);
           
            var actualStatusCode = response.StatusCode;
            
            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/campaigns", "C1", HttpStatusCode.NotFound, "Campaign not found: C1")]
        public async Task Return_Not_Found_Campaign(string url, string campaignName, HttpStatusCode expectedStatusCode, string expectedResult)
        {
            // Act
            var response = await _client.GetAsync($"{url}/{campaignName}");
            
            var actualStatusCode = response.StatusCode;
            var actualResponse = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(expectedResult, actualResponse);
        }
    }
}
