using Cashback.Domain.Dtos.Retailers;

namespace Cashback.Domain.Retailers
{

    public class Retailer{
        public string CPF { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public Retailer (CreateRetailerDto retailerInfo){
            CPF = retailerInfo.CPF;
            Name = retailerInfo.Name;
            Email = retailerInfo.Email;
            Password = retailerInfo.Password;
        }
    }
}