using Cashback.Application.Reports;
using Cashback.ExternalServices;
using Cashback.ExternalServices.Dtos;
using Cashback.ExternalServices.Options;
using Cashback.Repository.Context;
using Cashback.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Cashback.UnitTest.Services
{
    [Trait("Balance Tests", "service")]
    public class BalanceReportServiceTests
    {
        [Fact]
        public async Task Get_Balance_Amount_Succeed()
        {
            var optionsDB = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;
            var options = GetOptions();
            var endPoints = new List<(string, object, HttpStatusCode)>
            {
                ($"{options.Value.BalanceApiUrl}{options.Value.BalanceEndpoint}", new BalanceDtoResponse(){ StatusCode = 200, Body = new BalanceDtoResponse.BalanceDtoModel(){Credit=200} }, HttpStatusCode.OK)
            };
            var httpClientFactoryMock = GetFakeHttpClientFactoryMockEndPoints(options.Value.BalanceApiUrl, endPoints);

            using (var context = new CashbackContext(optionsDB))
            {
                context.Database.EnsureCreated();
                var retailerRepository = new RetailerRepository(context);

                var balanceService = new BalanceService(options, httpClientFactoryMock.Object);
                var balanceReportService = new BalanceReportService(retailerRepository, balanceService);

                var balance = await balanceReportService.GetRetailerBalance("15350946056");

                Assert.Equal(200, balance.Balance);

            }

        }


        [Fact]
        public async Task Get_Balance_Amount_Fail_On_External_Service_Fail()
        {
            var optionsDB = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;
            var options = GetOptions();
            var endPoints = new List<(string, object, HttpStatusCode)>
            {
                ($"{options.Value.BalanceApiUrl}{options.Value.BalanceEndpoint}",null, HttpStatusCode.BadRequest)
            };
            var httpClientFactoryMock = GetFakeHttpClientFactoryMockEndPoints(options.Value.BalanceApiUrl, endPoints);

            using (var context = new CashbackContext(optionsDB))
            {
                context.Database.EnsureCreated();
                var retailerRepository = new RetailerRepository(context);

                var balanceService = new BalanceService(options, httpClientFactoryMock.Object);
                var balanceReportService = new BalanceReportService(retailerRepository, balanceService);

                await Assert.ThrowsAsync<HttpRequestException>(() => balanceReportService.GetRetailerBalance("15350946056"));
            }

        }


        [Fact]
        public async Task Get_Balance_Amount_Fail_On_Retailer_Not_Found()
        {
            var optionsDB = new DbContextOptionsBuilder<CashbackContext>()
             .UseInMemoryDatabase(databaseName: $"Teste_OrderService{Guid.NewGuid()}")
             .Options;
            var options = GetOptions();
            var endPoints = new List<(string, object, HttpStatusCode)>
            {
                ($"{options.Value.BalanceApiUrl}{options.Value.BalanceEndpoint}",null, HttpStatusCode.BadRequest)
            };
            var httpClientFactoryMock = GetFakeHttpClientFactoryMockEndPoints(options.Value.BalanceApiUrl, endPoints);

            using (var context = new CashbackContext(optionsDB))
            {
                context.Database.EnsureCreated();
                var retailerRepository = new RetailerRepository(context);

                var balanceService = new BalanceService(options, httpClientFactoryMock.Object);
                var balanceReportService = new BalanceReportService(retailerRepository, balanceService);

                await Assert.ThrowsAsync<ArgumentException>(() => balanceReportService.GetRetailerBalance("408.477.340-99"));
            }

        }

        public Mock<IHttpClientFactory> GetFakeHttpClientFactoryMockEndPoints(string baseUrl, IEnumerable<(string url, object payload, HttpStatusCode status)> endpoints)
        {
            var mockHttpHandler = new MockHttpMessageHandler();

            foreach (var endpoint in endpoints)
                mockHttpHandler.When(endpoint.url).Respond(endpoint.status, "application/json", JsonConvert.SerializeObject(endpoint.payload));

            var client = new HttpClient(mockHttpHandler);
            if (!string.IsNullOrEmpty(baseUrl))
                client.BaseAddress = new Uri(baseUrl);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

            return httpClientFactoryMock;
        }

        public IOptions<BalanceApiOptions> GetOptions()
        {
            return Options.Create(new BalanceApiOptions
            {
                BalanceApiUrl = "http://baseurl",
                BalanceEndpoint = "/api/Endpoint",
                Token = "token"
            });
        }
    }
}
