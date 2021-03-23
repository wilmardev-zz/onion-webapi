using System;
using System.Threading.Tasks;
using XpertGroup.Users.Domain.Entities;
using XpertGroup.Users.Domain.Interfaces.Adapters;
using XpertGroup.Users.Domain.Interfaces.Services;

namespace XpertGroup.Users.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IGitHubAdapter gitHubAdapter;

        public UserService(IGitHubAdapter gitHubAdapter)
        {
            this.gitHubAdapter = gitHubAdapter;
        }


        public async Task<User> GetUser(string userName)
        {
            var user = await this.gitHubAdapter.GetDataByUserName(userName);
            user.CreatedDays = (DateTime.Now - user.CreatedDate).Days;
            return user;
        }
    }
}
