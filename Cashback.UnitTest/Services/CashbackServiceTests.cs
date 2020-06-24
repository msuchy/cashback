using Cashback.Application;
using Xunit;

namespace Cashback.UnitTest.Services
{
    [Trait("Cashback Tests", "service")]
    public class CashbackServiceTests
    {
        [Theory]
        [InlineData(0,0.1)]
        [InlineData(999.99,0.1)]
        [InlineData(1000,0.15)]
        [InlineData(1499.99,0.15)]
        [InlineData(1500,0.2)]
        [InlineData(9000,0.2)]
        public void Cashback_Percent_Value_Test(decimal totalAmount, decimal cashbackPercent) 
        {
            var cashbackService = new CashbackService();

            var percent = cashbackService.GetPercentByTotalAmount(totalAmount);
            Assert.Equal(cashbackPercent, percent);
        }
    }
}
