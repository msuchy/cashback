using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;

namespace Cashback.Application
{
    public class AuthService : IAuthService
    {
        private readonly IRetailerRepository _retailerRepository;
        public AuthService(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;
        }

        public async Task<bool> Login(string username, string password)
        {
            var retailer = await _retailerRepository.Find(username);
            if (retailer == null ||
                password != retailer.Password) 
                return false;

            return true;
        }
    }
}
