using Cashback.Repository.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cashback.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {


            var host = CreateHostBuilder(args).Build();

            // Roda as migrations do EF
            using (var scope = host.Services.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetService<CashbackContext>())
                {
                    dbContext.Database.EnsureCreated();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
        }

    }
}
