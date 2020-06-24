using Cashback.Domain.Services;
using Cashback.ExternalServices.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Cashback.ExternalServices
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<BalanceApiOptions>(config.GetSection("BalanceApiSettings"));
            services.AddHttpClient("balance-service", c =>
            {
                c.Timeout = TimeSpan.FromSeconds(5);
            });

            services.AddScoped<IBalanceService, BalanceService>();

            return services;
        }
    }
}
