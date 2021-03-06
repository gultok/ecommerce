﻿using ECommerce.Api;
using ECommerce.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.ApiTests
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
        [InlineData("/products", HttpStatusCode.MethodNotAllowed)]
        public async Task Return_Method_Not_Allowed_Error_Without_Product_Code(string url, HttpStatusCode expectedStatusCode)
        {
            // Act
            var response = await _client.GetAsync(url);
            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/products", "P1", HttpStatusCode.NotFound)]
        public async Task Return_Not_Found_Product(string url, string productCode, HttpStatusCode expectedStatusCode)
        {
            var expectedResult = $"Product not found: {productCode}";

            // Act
            var response = await _client.GetAsync($"{url}/{productCode}");

            var actualStatusCode = response.StatusCode;
            var actualResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Equal(expectedResult, actualResponse);
        }

        [Theory]
        [InlineData("/products", HttpStatusCode.UnsupportedMediaType)]
        public async Task Return_Unsupported_Media_Type_Without_Product_Info(string url, HttpStatusCode expectedStatusCode)
        {
            // Act
            var response = await _client.PostAsync(url, null);

            var actualStatusCode = response.StatusCode;

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Theory]
        [InlineData("/products", "P41", 10, 100, HttpStatusCode.OK)]
        public async Task Return_OK_When_Product_Created(string createProductUrl, string productCode, double price, int stock, HttpStatusCode expectedStatusCode)
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
        [InlineData("/products", "P1", HttpStatusCode.OK)]
        public async Task Return_OK_And_Get_Product_Info(string url, string productCode, HttpStatusCode expectedStatusCode)
        {
            var expectedResult = $"Product {productCode} info;";

            var createProductRequest = new ProductInput
            {
                ProductCode = productCode,
                Price = 100,
                Stock = 50
            };
            var createProductContent = new StringContent(JsonConvert.SerializeObject(createProductRequest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/products", createProductContent);

            // Act
            var response = await _client.GetAsync($"{url}/{productCode}");

            var actualStatusCode = response.StatusCode;
            var actualResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedStatusCode, actualStatusCode);
            Assert.Contains(expectedResult, actualResponse);
        }

        [Theory]
        [InlineData("/products", null, 10, 100, HttpStatusCode.BadRequest)]
        public async Task Return_Bad_Request_Without_ProductCode(string createProductUrl, string productCode, double price, int stock, HttpStatusCode expectedStatusCode)
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
    }
}
