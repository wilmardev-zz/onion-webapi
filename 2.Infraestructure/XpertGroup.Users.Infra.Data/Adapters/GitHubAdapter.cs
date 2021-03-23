using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XpertGroup.Users.Domain.Entities;
using XpertGroup.Users.Domain.Interfaces.Adapters;
using XpertGroup.Users.Infra.Data.DTO;

namespace XpertGroup.Users.Infra.Data.Adapters
{
    public class GitHubAdapter : IGitHubAdapter
    {
        private readonly IBaseAdapter baseAdapter;
        public GitHubAdapter(IBaseAdapter baseAdapter)
        {
            this.baseAdapter = baseAdapter;
        }

        public async Task<User> GetDataByUserName(string userName)
        {
            var url = $"https://api.github.com/users/{userName}";
            var data = await this.baseAdapter.Get<UserGitHubDTO>(url);
            return new User
            {
                UserName = data.Name,
                CreatedDate = data.Created_At
            };
        }
    }
}
