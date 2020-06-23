namespace Cashback.Domain.Dtos.Retailers
{
    public class CreateRetailerDto{
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}