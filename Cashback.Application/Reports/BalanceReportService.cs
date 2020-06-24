using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Reports;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Cashback.Application.Reports
{
    public class BalanceReportService : IBalanceReportService
    {
        private readonly IBalanceService _balanceService;
        private readonly IRetailerRepository _retailerRepository;
        public BalanceReportService(IRetailerRepository retailerRepository, IBalanceService balanceService)
        {
            _balanceService = balanceService;
            _retailerRepository = retailerRepository;
        }
        public async Task<BalanceDto> GetRetailerBalance(string retailerCpf)
        {
            var cpf = new Cpf(retailerCpf);
            var retailer = await _retailerRepository.Find(cpf);
            if (retailer == null)
                throw new ArgumentException("Retailer not found");

            var balance = await _balanceService.GetRetailerBalance(cpf);

            return new BalanceDto() { Balance = balance };
        }
    }
}
