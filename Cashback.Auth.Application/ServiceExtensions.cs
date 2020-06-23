using Cashback.Auth.Application.Options;
using Cashback.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Cashback.Auth.Application
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterAuthApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AuthenticationOptions>(config.GetSection("Authentication"));

            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            return services;
        }
    }
}
