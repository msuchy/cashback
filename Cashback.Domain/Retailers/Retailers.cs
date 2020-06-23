using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Retailers;

namespace Cashback.Domain.Retailers
{
    public class Retailer{
        public Cpf CPF { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }

        public Retailer (CreateRetailerDto retailerInfo){
            CPF = new Cpf(retailerInfo.CPF);
            Name = retailerInfo.Name;
            Email = new Email(retailerInfo.Email);
            Password = retailerInfo.Password;
        }
    }
}