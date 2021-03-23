using System;
using System.Threading.Tasks;
using Moq;
using XpertGroup.Users.Domain.Entities;
using XpertGroup.Users.Domain.Interfaces.Adapters;
using XpertGroup.Users.Domain.Services;
using Xunit;

namespace XpertGroup.Users.Test.UnitTests
{
    public class UserServiceTest : IDisposable
    {
        private MockRepository mockRepository;
        private Mock<IGitHubAdapter> mockGitHubAdapter;

        public UserServiceTest()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockGitHubAdapter = mockRepository.Create<IGitHubAdapter>();
        }

        [Theory]
        [InlineData("2020-05-06", 321)]
        [InlineData("2021-01-03", 79)]
        [InlineData("2021-03-22", 1)]
        public async Task VerifyUserCreatedDate_InDays_Test(string userCreateDate, int daysExceptect)
        {
            var userService = new UserService(mockGitHubAdapter.Object);
            var userMock = new User { CreatedDate = Convert.ToDateTime(userCreateDate) };
            mockGitHubAdapter.Setup(s => s.GetDataByUserName("wilmardev")).Returns(Task.FromResult(userMock));
            var user = await userService.GetUser("wilmardev");
            Assert.Equal(user.CreatedDays, daysExceptect);
        }

        public void Dispose()
        {
            mockRepository.VerifyAll();
        }
    }
}
