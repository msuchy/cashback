using Cashback.Domain.Dtos.Auth;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using System.Threading.Tasks;

namespace Cashback.Auth.Application
{
    public class AuthService : IAuthService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthService(IRetailerRepository retailerRepository, IJwtTokenService jwtTokenService)
        {
            _retailerRepository = retailerRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<TokenDto> Login(LoginDto loginInfo)
        {
            var retailer = await _retailerRepository.Find(loginInfo.CPF);
            if (retailer == null ||
                loginInfo.Password != retailer.Password) 
                return null;

            return new TokenDto { Token = _jwtTokenService.CreateJwtToken(retailer.CPF) };
        }
    }
}
