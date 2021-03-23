using System;
using Microsoft.Extensions.DependencyInjection;
using XpertGroup.Users.Application.Interfaces;
using XpertGroup.Users.Application.Services;
using XpertGroup.Users.Domain.Interfaces.Adapters;
using XpertGroup.Users.Domain.Interfaces.Services;
using XpertGroup.Users.Domain.Services;
using XpertGroup.Users.Infra.Data.Adapters;

namespace XpertGroup.Users.Infra.IoC
{
    public class DependencyInjector
    {
        public IServiceCollection GetServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();
            // Adapters
            services.AddSingleton<IBaseAdapter, BaseAdapter>();
            services.AddSingleton<IGitHubAdapter, GitHubAdapter>();

            // Services
            services.AddSingleton<IUserService, UserService>();

            // Applications
            services.AddSingleton<IUserApplication, UserApplication>();

            return services;
        }
    }
}
