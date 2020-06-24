using Cashback.Application;
using Cashback.Application.Retailers;
using Cashback.Domain.Common;
using Cashback.Repository.Context;
using Cashback.Repository.Models;
using Cashback.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Cashback.UnitTest.Services
{
    public class RetailerServiceTests
    {
        [Fact]
        public async Task Create_Retailer_Success()
        {
            var options = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;

            var retailerCpf = new Cpf("408.477.340-99");
            var passwordHasher = new PasswordHasher();


            using (var context = new CashbackContext(options))
            {

                var retailerRepository = new RetailerRepository(context);

                var retailerService = new RetailerService(retailerRepository, passwordHasher);

                await retailerService.Create(new Domain.Dtos.Retailers.CreateRetailerDto()
                {
                    CPF = retailerCpf.Value,
                    Name = "Test name",
                    Email = "naotem@naotem.com",
                    Password = "bla"
                });

            }
            using (var context = new CashbackContext(options))
            {
                var retailer = await context.Set<RetailerDbModel>()
                    .FirstOrDefaultAsync(r => r.CPF == retailerCpf.Value);

                Assert.NotNull(retailer);
                Assert.Equal(retailerCpf.Value, retailer.CPF);
                Assert.Equal("naotem@naotem.com", retailer.Email);
                Assert.True(passwordHasher.Check(retailer.Password, "bla"));
            }
        }

        [Fact]
        public async Task Create_Duplicated_Retailer_Fail()
        {
            var options = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;

            var retailerCpf = new Cpf("408.477.340-99");
            var passwordHasher = new PasswordHasher();


            using (var context = new CashbackContext(options))
            {

                var retailerRepository = new RetailerRepository(context);

                var retailerService = new RetailerService(retailerRepository, passwordHasher);

                await retailerService.Create(new Domain.Dtos.Retailers.CreateRetailerDto()
                {
                    CPF = retailerCpf.Value,
                    Name = "Test name",
                    Email = "naotem@naotem.com",
                    Password = "bla"
                });

                await Assert.ThrowsAnyAsync<Exception>(() => retailerService.Create(new Domain.Dtos.Retailers.CreateRetailerDto()
                {
                    CPF = retailerCpf.Value,
                    Name = "Test name",
                    Email = "naotem@naotem.com",
                    Password = "bla"
                }));
            }

            using (var context = new CashbackContext(options))
            {
                var retailer = await context.Set<RetailerDbModel>()
                    .FirstOrDefaultAsync(r => r.CPF == retailerCpf.Value);

                Assert.NotNull(retailer);
                Assert.Equal(retailerCpf.Value, retailer.CPF);
                Assert.Equal("naotem@naotem.com", retailer.Email);
                Assert.True(passwordHasher.Check(retailer.Password, "bla"));
            }
        }

        [Fact]
        public async Task Create_Retailer_With_Invalid_Cpf_Fail()
        {
            var options = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;

            var passwordHasher = new PasswordHasher();

            using (var context = new CashbackContext(options))
            {

                var retailerRepository = new RetailerRepository(context);

                var retailerService = new RetailerService(retailerRepository, passwordHasher);

                await Assert.ThrowsAnyAsync<ArgumentException>(() => retailerService.Create(new Domain.Dtos.Retailers.CreateRetailerDto()
                {
                    CPF = "",
                    Name = "Test name",
                    Email = "naotem@naotem.com",
                    Password = "bla"
                }));
            }

        }
    }
}
