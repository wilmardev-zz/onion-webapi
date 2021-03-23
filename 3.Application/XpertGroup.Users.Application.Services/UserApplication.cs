using System;
using System.Threading.Tasks;
using XpertGroup.Users.Application.Interfaces;
using XpertGroup.Users.Domain.Entities;
using XpertGroup.Users.Domain.Interfaces.Services;

namespace XpertGroup.Users.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService userService;

        public UserApplication(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<GeneralResponse> Get(string userName)
        {
            try
            {
                var data =  await this.userService.GetUser(userName);
                return new GeneralResponse
                {
                    Success = true,
                    Information = data
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse { Success = false };
            }
        }
    }
}
