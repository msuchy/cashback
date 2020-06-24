using Cashback.Domain.Common;
using System.Threading.Tasks;

namespace Cashback.Domain.Services
{
    public interface IBalanceService
    {
        Task<decimal> GetRetailerBalance(Cpf cpf);
    }
}
