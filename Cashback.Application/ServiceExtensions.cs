using System;
using System.Diagnostics.CodeAnalysis;
using Cashback.Application.Retailers;
using Cashback.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cashback.Application
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRetailerService, RetailerService>();
            return services;
        }
    }
}
