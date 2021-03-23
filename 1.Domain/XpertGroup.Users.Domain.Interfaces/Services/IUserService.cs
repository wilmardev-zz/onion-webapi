using System;
using System.Threading.Tasks;
using XpertGroup.Users.Domain.Entities;

namespace XpertGroup.Users.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string userName); 
    }
}
