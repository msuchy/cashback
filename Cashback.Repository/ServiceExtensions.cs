using System.Diagnostics.CodeAnalysis;
using Cashback.Domain.Repositories;
using Cashback.Repository.Context;
using Cashback.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cashback.Repository
{
    [ExcludeFromCodeCoverage]
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddDbContext<CashbackContext>(opt => opt.UseInMemoryDatabase(databaseName: "Test"));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRetailerRepository, RetailerRepository>();
            return services;
        }
    }
}
