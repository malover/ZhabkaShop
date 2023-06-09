using Application.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ZhabkaShop.UnitTests
{
    public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProductsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Products_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/products/");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_ProductById_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var id = 1;

            // Act
            var response = await client.GetAsync($"/products/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_AddProduct_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var product = new ProductDto {Name = "Dull name", Price = 100, Quantity = 100};
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/products/", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Put_UpdateProduct_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var id = 1;
            var product = new ProductDto { Name = "Dull name", Price = 101, Quantity = 101 };
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync($"/products/{id}", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_DeleteProduct_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var id = 1;

            // Act
            var response = await client.DeleteAsync($"/products/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
