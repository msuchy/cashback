namespace Cashback.ExternalServices.Dtos
{
    public class BalanceDtoResponse
    {
        public int StatusCode { get; set; }
        public BalanceDtoModel Body { get; set; }
        public class BalanceDtoModel
        {
            public decimal Credit { get; set; }
        }
    }
}
