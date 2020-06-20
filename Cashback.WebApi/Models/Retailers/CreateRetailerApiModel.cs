namespace Cashback.WebApi.Models.Retailers
{
    public class CreateRetailerApiModel{
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}