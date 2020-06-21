namespace Cashback.Domain.Retailers{

    public class Retailer{
        public string CPF { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public Retailer (string cpf, string name, string email, string password){
            CPF = cpf;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}