using System.Threading.Tasks;
using XpertGroup.Users.Domain.Entities;

namespace XpertGroup.Users.Domain.Interfaces.Adapters
{
    public interface IGitHubAdapter
    {
        Task<User> GetDataByUserName(string userName);
    }
}
