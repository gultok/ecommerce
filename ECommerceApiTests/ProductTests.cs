using ECommerceApi;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiTests
{
    public class ProductTests
    {
        private readonly HttpClient _client;
        public ProductTests()
        {
            var testServer = new TestServer(new WebHostBuilder()
                                            .UseStartup<Startup>()
                                            .UseEnvironment("Development"));
            _client = testServer.CreateClient();
        }

        [Theory]
        [InlineData("/product/get-product-info", HttpStatusCode.NotFound)]
        public async Task Return_Not_Found_Error_Without_Product_Code(string url, HttpStatusCode expectedStatusCode)
        {
            // Act
            var response = await _client.GetAsync(url);
            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/product/get-product-info", "P1", HttpStatusCode.OK)]
        public async Task Return_OK_And_Not_Found_Product(string url, string productCode, HttpStatusCode expectedStatusCode)
        {
            var expectedResult = $"Product not found: {productCode}";

            // Act
            var response = await _client.GetAsync($"{url}/{productCode}");

            var actualStatusCode = response.StatusCode;
            var actualResponse = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(expectedResult, actualResponse);
        }

        [Theory]
        [InlineData("/product/create-product", HttpStatusCode.UnsupportedMediaType)]
        public async Task Return_Unsupported_Media_Type_Without_Product_Info(string url, HttpStatusCode expectedStatusCode)
        {
            // Act
            var response = await _client.PostAsync(url, null);

            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/product/create-product", "P1", 10, 100, HttpStatusCode.OK)]
        public async Task Return_OK_When_Product_Created(string createProductUrl, string productCode, double price, double stock, HttpStatusCode expectedStatusCode)
        {
            var expectedResult = $"Product created; code {productCode}, price {price}, stock {stock}";

            // Arrange
            var request = new ProductInput
            {
                ProductCode = productCode,
                Price = price,
                Stock = stock
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(createProductUrl, content);

            var actualStatusCode = response.StatusCode;
            var actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/product/get-product-info", "P1", HttpStatusCode.OK)]
        public async Task Return_OK_And_Get_Product_Info(string url, string productCode, HttpStatusCode expectedStatusCode)
        {
            var expectedResult = $"Product {productCode} info;";

            // Act
            var response = await _client.GetAsync($"{url}/{productCode}");

            var actualStatusCode = response.StatusCode;
            var actualResponse = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Contains(expectedResult, actualResponse);
        }

        [Theory]
        [InlineData("/product/create-product", null, 10, 100, HttpStatusCode.BadRequest)]
        public async Task Return_Bad_Request_Without_ProductCode(string createProductUrl, string productCode, double price, double stock, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var request = new ProductInput
            {
                ProductCode = productCode,
                Price = price,
                Stock = stock
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(createProductUrl, content);

            var actualStatusCode = response.StatusCode;

            //Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        //[InlineData("/product/create-product", "P1", 10, 100)]

    }
}
