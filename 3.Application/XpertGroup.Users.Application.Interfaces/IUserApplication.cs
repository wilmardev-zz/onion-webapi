using System;
using System.Threading.Tasks;
using XpertGroup.Users.Domain.Entities;

namespace XpertGroup.Users.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<GeneralResponse> Get(string userName);
    }
}
