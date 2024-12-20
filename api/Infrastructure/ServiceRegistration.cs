using api.Repositories.Interfaces;
using API.Repositories;
using API.Services;
using API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace api.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();

            // Add more registrations here...
        }
    }
}