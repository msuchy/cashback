using System.Threading.Tasks;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;

namespace Cashback.Application.Retailers{
    public class RetailerService : IRetailerService
    {
        private readonly IRetailerRepository _retailerRepository;
        public RetailerService(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;
        }
        public async Task Create(string cpf, string name, string email, string password)
        {
            await _retailerRepository.Add(new Domain.Retailers.Retailer(cpf, name, email, password));
        }
    }
}