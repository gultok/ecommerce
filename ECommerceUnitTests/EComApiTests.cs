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

namespace ECommerceUnitTests
{
    public class EComApiTests
    {
        private readonly HttpClient _client;
        public EComApiTests()
        {
            var testServer = new TestServer(new WebHostBuilder()
        .UseStartup<Startup>()
        .UseEnvironment("Development"));
            _client = testServer.CreateClient();
        }

        [Theory]
        [InlineData("/product/get-product")]
        public async Task Return_Not_Found_Error_Without_Product_Code(string url)
        {
            var expectedStatusCode = HttpStatusCode.NotFound;
            var response = await _client.GetAsync(url);
            var actualStatusCode = response.StatusCode;
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/product/create-product")]
        public async Task Return_Unsupported_Media_Type_Without_Product_Info(string url)
        {
            var expectedStatusCode = HttpStatusCode.UnsupportedMediaType;
            var response = await _client.PostAsync(url, null);
            var actualStatusCode = response.StatusCode;
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/product/create-product", "P1", 10, 100)]
        public async Task Return_OK_When_Product_Created(string createProductUrl, string productCode, double price, double stock)
        {
            var request = new ProductParam
            {
                ProductCode = productCode,
                Price = price,
                Stock = stock
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var expectedResult = $"Product created; code {productCode}, price {price}, stock {stock}";
            var expectedStatusCode = HttpStatusCode.OK;

            var response = await _client.PostAsync(createProductUrl, content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert-1
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedStatusCode, actualStatusCode);

        }
        [Theory]
        [InlineData("/product/create-product", null, 10, 100)]
        [InlineData("/product/create-product", "P1", 10, 100)]
        public async Task Return_Bad_Request_Without_ProductCode(string createProductUrl, string productCode, double price, double stock)
        {
            var request = new ProductParam
            {
                ProductCode = productCode,
                Price = price,
                Stock = stock
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var expectedStatusCode = HttpStatusCode.BadRequest;

            var response = await _client.PostAsync(createProductUrl, content);

            var actualStatusCode = response.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
