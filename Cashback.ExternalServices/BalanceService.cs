using Cashback.Domain.Common;
using Cashback.Domain.Services;
using Cashback.ExternalServices.Dtos;
using Cashback.ExternalServices.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cashback.ExternalServices
{
    public class BalanceService : IBalanceService
    {
        private readonly BalanceApiOptions _options;
        private readonly HttpClient _httpClient;
        public BalanceService(IOptions<BalanceApiOptions> options, IHttpClientFactory httpFactory)
        {
            _options = options.Value;
            _httpClient = httpFactory.CreateClient("balance-service");

        }

        public async Task<decimal> GetRetailerBalance(Cpf cpf)
        {
            var response = await _httpClient.GetAsync($"{_options.BalanceApiUrl}{_options.BalanceEndpoint}?cpf={cpf.Value}");

            if (response.IsSuccessStatusCode)
            {
                var balance = JsonConvert.DeserializeObject<BalanceDtoResponse>(await response.Content.ReadAsStringAsync());

                if (balance.StatusCode == 200)
                {
                    return balance.Body.Credit;
                }
            }
            throw new HttpRequestException("Invalid balance api request");
        }
    }
}
