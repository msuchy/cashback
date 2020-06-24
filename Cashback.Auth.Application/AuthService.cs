using Cashback.Domain.Common;
using Cashback.Domain.Dtos.Auth;
using Cashback.Domain.Repositories;
using Cashback.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Cashback.Auth.Application
{
    public class AuthService : IAuthService
    {
        private readonly IRetailerRepository _retailerRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IRetailerRepository retailerRepository, IJwtTokenService jwtTokenService, IPasswordHasher passwordHasher, ILogger<AuthService> logger)
        {
            _retailerRepository = retailerRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<TokenDto> Login(LoginDto loginInfo)
        {
            _logger.LogInformation($"Login requested for {loginInfo.CPF}");
            var retailer = await _retailerRepository.Find(new Cpf(loginInfo.CPF));
            if (retailer == null ||
                !_passwordHasher.Check(retailer.Password, loginInfo.Password))
            {
                _logger.LogInformation($"Login {loginInfo.CPF} not found or wrong password");
                return null;
            }

            _logger.LogInformation($"Login succeed for {loginInfo.CPF}");
            return new TokenDto { Token = _jwtTokenService.CreateJwtToken(retailer.CPF.Value) };
        }
    }
}
