using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cashback.WebApi.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cashback.WebApi.Util
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly AuthenticationOptions _authOptions;
        public JwtTokenService(IOptions<AuthenticationOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }

        public string CreateJwtToken(string name)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_authOptions.IssuerSigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("name", name)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}