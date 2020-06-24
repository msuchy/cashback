using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Reports;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IBalanceReportService
    {
        Task<BalanceDto> GetRetailerBalance(string retailerCpf);
    }
}
