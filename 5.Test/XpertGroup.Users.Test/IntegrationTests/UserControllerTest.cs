using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using XpertGroup.Users.WebApi;
using Xunit;

namespace XpertGroup.Users.Test.IntegrationTests
{
    public class UserControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UserControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/user/wilmardev")]
        public async Task GetUserInfo_Test(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.Equal(200, (int)response.StatusCode);
        }
    }
}
