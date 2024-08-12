using SimpleBlogApp.Abstraction.Interface;
using SimpleBlogApp.Application.Services;
using SimpleBlogApp.Infra.Data.Repository.Interfaces;
using SimpleBlogApp.Infra.Data.Repository;
using SimpleBlogApp.API.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace SimpleBlogApp.API.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserClientService, UserClientService>();
            services.AddScoped<IPostClientService, PostClientService>();
            services.AddSingleton<AuthService>();

            return services;
        }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
