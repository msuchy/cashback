using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Reports;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cashback.Application.Reports
{
    public class BalanceReportService : IBalanceReportService
    {
        private readonly IBalanceService _balanceService;
        private readonly IRetailerRepository _retailerRepository;
        private readonly ILogger<BalanceReportService> _logger;
        public BalanceReportService(IRetailerRepository retailerRepository, IBalanceService balanceService, ILogger<BalanceReportService> logger)
        {
            _balanceService = balanceService;
            _retailerRepository = retailerRepository;
            _logger = logger;
        }
        public async Task<BalanceDto> GetRetailerBalance(string retailerCpf)
        {
            _logger.LogInformation($"GetRetailerBalance requested for p{retailerCpf}");
            var cpf = new Cpf(retailerCpf);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer == null)
            {
                _logger.LogError($"Retailer not found {retailerCpf}");
                throw new ArgumentException("Retailer not found");

            }

            var balance = await _balanceService.GetRetailerBalance(cpf);

            return new BalanceDto() { Balance = balance };
        }
    }
}
