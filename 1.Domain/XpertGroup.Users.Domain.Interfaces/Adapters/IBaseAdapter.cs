using System;
using System.Threading.Tasks;

namespace XpertGroup.Users.Domain.Interfaces.Adapters
{
    public interface IBaseAdapter
    {
        Task<T> Get<T>(string url);
    }
}
