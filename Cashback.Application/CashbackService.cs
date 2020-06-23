using Cashback.Domain.Services;

namespace Cashback.Application
{
    public class CashbackService : ICashbackService
    {
        public decimal GetPercentByTotalAmount(decimal totalAmount)
        {
            if (totalAmount < 1000)
                return 0.1M;
            if (totalAmount < 1500)
                return 0.15M;
            return 0.2M;
        }
    }
}
