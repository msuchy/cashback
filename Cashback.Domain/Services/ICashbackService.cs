namespace Cashback.Domain.Services
{
    public interface ICashbackService
    {
        decimal GetPercentByTotalAmount(decimal totalAmount);
    }
}
