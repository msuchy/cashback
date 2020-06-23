using Cashback.Domain.Dtos.Retailers;
using Cashback.Domain.Repositories;
using Cashback.Domain.Retailers;
using Cashback.Domain.Services;
using System.Threading.Tasks;

namespace Cashback.Application.Retailers
{
    public class RetailerService : IRetailerService
    {
        private readonly IRetailerRepository _retailerRepository;
        public RetailerService(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;
        }
        public async Task Create(CreateRetailerDto retailerInfo)
        {
            await _retailerRepository.Add(new Retailer(retailerInfo));
        }
    }
}