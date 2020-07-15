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
        [InlineData("/orders", HttpStatusCode.UnsupportedMediaType)]
        public async Task Return_Unsupported_Media_Type_Without_Order_Info(string url, HttpStatusCode expectedStatusCode)
        {
            // Act
            var response = await _client.PostAsync(url, null);
            
            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/orders", null, 10, HttpStatusCode.BadRequest)]
        [InlineData("/orders", "P3", 0, HttpStatusCode.BadRequest)]
        public async Task Return_Bad_Request_Without_ProductCode_Or_Quantity(string url, string productCode, int quantity, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var request = new OrderInput
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);
            
            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/orders", "P3", 15, HttpStatusCode.NotFound, "Product not found P3")]
        public async Task Return_Not_Found_Product(string url, string productCode, int quantity, HttpStatusCode expectedStatusCode, string expectedResult)
        {
            // Arrange
            var request = new OrderInput
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);
            
            var actualStatusCode = response.StatusCode;
            var actualResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(expectedResult, actualResponse);
        }

        //create product???

        [Theory]
        [InlineData("/orders", "P40", 100, HttpStatusCode.BadRequest, "Product P40 saleable stock is")]
        public async Task Return_Bad_Request_Product_Stock_Is_Not_Enough(string url, string productCode, int quantity, HttpStatusCode expectedStatusCode, string expectedResult)
        {
            // Arrange
            var createProductRequest = new ProductInput
            {
                ProductCode = productCode,
                Price = 100,
                Stock = 50
            };
            var createProductContent = new StringContent(JsonConvert.SerializeObject(createProductRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/products", createProductContent);


            var request = new OrderInput
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);
            
            var actualStatusCode = response.StatusCode;
            var actualResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Contains(expectedResult, actualResponse);
        }

        [Theory]
        [InlineData("/orders", "P3", "TEN", HttpStatusCode.BadRequest)]
        public async Task Return_Bad_Request_Quantity_Is_Not_Number(string url, string productCode, string quantity, HttpStatusCode expectedStatusCode)
        {
            // Arrange           
            var request = new
            {
                ProductCode = productCode,
                Quantity = quantity
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);
            
            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
