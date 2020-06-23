using Cashback.Application.Retailers;
using Cashback.Domain.Common;
using Cashback.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Cashback.Application
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IRetailerService, RetailerService>();
            return services;
        }
    }
}
