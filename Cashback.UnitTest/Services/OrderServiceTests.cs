using Cashback.Application;
using Cashback.Application.Orders;
using Cashback.Domain.Common;
using Cashback.Domain.Orders;
using Cashback.Repository.Context;
using Cashback.Repository.Models;
using Cashback.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cashback.UnitTest.Services
{
    [Trait("Order Tests", "service")]
    public class OrderServiceTests
    {
        [Fact]
        public async Task List_Only_Current_Month_Orders()
        {
            var options = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;

            var retailerCpf = new Cpf("408.477.340-99");
            var orderReferenceDate = DateTime.Now;


            using (var context = new CashbackContext(options))
            {

                var retailerRepository = new RetailerRepository(context);

                await retailerRepository.Add(new Domain.Retailers.Retailer(new Domain.Dtos.Retailers.CreateRetailerDto()
                {
                    CPF = retailerCpf.Value,
                    Name = "Test name",
                    Email = "naotem@naotem.com",
                    Password = "bla"
                }));

                var retailer = await retailerRepository.Find(retailerCpf);


                var orderRepository = new OrderRepository(context);

                await orderRepository.Add(new Order("ABC", 20, orderReferenceDate.AddMonths(-5), retailer));
                await orderRepository.Add(new Order("DEF", 30, orderReferenceDate, retailer));
                await orderRepository.Add(new Order("GHI", 40, orderReferenceDate.AddMonths(5), retailer));
            }
            using (var context = new CashbackContext(options))
            {
                var retailerRepository = new RetailerRepository(context);
                var orderRepository = new OrderRepository(context);


                var orderService = new OrderService(
                    retailerRepository,
                    orderRepository,
                    new CashbackService());

                var orders = await orderService.ListCurrentMonth(retailerCpf.Value);

                Assert.Single(orders);
                Assert.Equal("DEF", orders.First().Code);
                Assert.Equal(30, orders.First().Value);
                Assert.Equal(OrderStatus.Validating, orders.First().Status);
                Assert.Equal(orderReferenceDate, orders.First().ReferenceDate);
                Assert.Equal(10, orders.First().CashbackPercent);
                Assert.Equal(3, orders.First().CashbackValue);
            }
        }


        [Fact]
        public async Task Create_Order_Success()
        {
            var options = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;

            var retailerCpf = new Cpf("408.477.340-99");
            var orderReferenceDate = DateTime.Now;


            using (var context = new CashbackContext(options))
            {

                var retailerRepository = new RetailerRepository(context);

                await retailerRepository.Add(new Domain.Retailers.Retailer(new Domain.Dtos.Retailers.CreateRetailerDto()
                {
                    CPF = retailerCpf.Value,
                    Name = "Test name",
                    Email = "naotem@naotem.com",
                    Password = "bla"
                }));

                var orderRepository = new OrderRepository(context);

                var orderService = new OrderService(
                    retailerRepository,
                    orderRepository,
                    new CashbackService());

                await orderService.Create(new Domain.Dtos.Orders.CreateOrderDto() {
                    Code = "ABC",
                    ReferenceDate = orderReferenceDate,
                    Value = 200
                }, retailerCpf.Value);

            }
            using (var context = new CashbackContext(options))
            {
                var orders = await context.Set<OrderDbModel>().ToListAsync();

                Assert.Single(orders);
                Assert.Equal("ABC", orders.First().Code);
                Assert.Equal(200, orders.First().Value);
                Assert.Equal(orderReferenceDate, orders.First().ReferenceDate);
                Assert.Equal(OrderStatus.Validating, orders.First().Status);
            }
        }

        [Fact]
        public async Task Create_Order_With_Approoved_Status_Success()
        {
            var options = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;

            var retailerCpf = new Cpf("15350946056");
            var orderReferenceDate = DateTime.Now;


            using (var context = new CashbackContext(options))
            {
                context.Database.EnsureCreated();

                var retailerRepository = new RetailerRepository(context);

                await retailerRepository.Add(new Domain.Retailers.Retailer(new Domain.Dtos.Retailers.CreateRetailerDto()
                {
                    CPF = retailerCpf.Value,
                    Name = "Test name",
                    Email = "naotem@naotem.com",
                    Password = "bla"
                }));

                var orderRepository = new OrderRepository(context);

                var orderService = new OrderService(
                    retailerRepository,
                    orderRepository,
                    new CashbackService());

                await orderService.Create(new Domain.Dtos.Orders.CreateOrderDto()
                {
                    Code = "ABC",
                    ReferenceDate = orderReferenceDate,
                    Value = 200
                }, retailerCpf.Value);

            }
            using (var context = new CashbackContext(options))
            {
                var orders = await context.Set<OrderDbModel>().ToListAsync();

                Assert.Single(orders);
                Assert.Equal("ABC", orders.First().Code);
                Assert.Equal(200, orders.First().Value);
                Assert.Equal(orderReferenceDate, orders.First().ReferenceDate);
                Assert.Equal(OrderStatus.Approved, orders.First().Status);
            }
        }
    }
}
