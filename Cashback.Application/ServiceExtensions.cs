using Cashback.Application.Retailers;
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

            services.AddScoped<IRetailerService, RetailerService>();
            return services;
        }
    }
}
