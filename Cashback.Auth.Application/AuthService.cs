using Cashback.Domain.Common;
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
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(IRetailerRepository retailerRepository, IJwtTokenService jwtTokenService, IPasswordHasher passwordHasher)
        {
            _retailerRepository = retailerRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<TokenDto> Login(LoginDto loginInfo)
        {
            var retailer = await _retailerRepository.Find(new Cpf(loginInfo.CPF));
            if (retailer == null ||
                !_passwordHasher.Check(retailer.Password, loginInfo.Password) )
                return null;

            return new TokenDto { Token = _jwtTokenService.CreateJwtToken(retailer.CPF.Value) };
        }
    }
}
