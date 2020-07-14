using ECommerce.ParameterObjects;
using ECommerceApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceUnitTests.EComApiTests
{
    public class OrderTests
    {
        private readonly HttpClient _client;
        public OrderTests()
        {
            var testServer = new TestServer(new WebHostBuilder()
                                            .UseStartup<Startup>()
                                            .UseEnvironment("Development"));
            _client = testServer.CreateClient();
        }

        [Theory]
        [InlineData("/order/create-order", HttpStatusCode.UnsupportedMediaType)]
        public async Task Return_Unsupported_Media_Type_Without_Order_Info(string url, HttpStatusCode expectedStatusCode)
        {
            var response = await _client.PostAsync(url, null);
            var actualStatusCode = response.StatusCode;
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/order/create-order", null, 10, HttpStatusCode.BadRequest)]
        [InlineData("/order/create-order", "P3", 0, HttpStatusCode.BadRequest)]
        public async Task Return_Bad_Request_Without_ProductCode_Or_Quantity(string url, string productCode, double quantity, HttpStatusCode expectedStatusCode)
        {
            var request = new OrderParam
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            var actualStatusCode = response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/order/create-order", "P3", 15, HttpStatusCode.OK, "Product not found P3")]
        public async Task Return_OK_Product_Not_Found(string url, string productCode, double quantity, HttpStatusCode expectedStatusCode, string expectedResult)
        {
            var request = new OrderParam
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            var actualStatusCode = response.StatusCode;
            var actualResponse = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(expectedResult, actualResponse);
        }

        //create product???

        [Theory]
        [InlineData("/order/create-order", "P3", 100, HttpStatusCode.OK, "Product saleable stock is")]
        public async Task Return_OK_Product_Stock_Is_Not_Enough(string url, string productCode, double quantity, HttpStatusCode expectedStatusCode, string expectedResult)
        {
            var request = new OrderParam
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            var actualStatusCode = response.StatusCode;
            var actualResponse = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Contains(expectedResult, actualResponse);
        }

        [Theory]
        [InlineData("/order/create-order", "P3", "TEN", HttpStatusCode.BadRequest)]
        public async Task Return_Bad_Request_Quantity_Is_Not_Number(string url, string productCode, string quantity, HttpStatusCode expectedStatusCode)
        {
            var request = new
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            var actualStatusCode = response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
