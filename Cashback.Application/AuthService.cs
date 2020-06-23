using Cashback.Domain.Dtos.Auth;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using System.Threading.Tasks;

namespace Cashback.Application
{
    public class AuthService : IAuthService
    {
        private readonly IRetailerRepository _retailerRepository;
        public AuthService(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;
        }

        public async Task<bool> Login(LoginDto loginInfo)
        {
            var retailer = await _retailerRepository.Find(loginInfo.CPF);
            if (retailer == null ||
                loginInfo.Password != retailer.Password) 
                return false;

            return true;
        }
    }
}
