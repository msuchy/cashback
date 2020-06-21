using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cashback.WebApi.Models.Auth;
using Cashback.WebApi.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cashback.WebApi.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Rota para validar um login de um revendedor(a);
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Post([FromBody]LoginApiModel request, [FromServices]IOptions<AuthenticationOptions> authOptions)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(authOptions.Value.IssuerSigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("name", "teste")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new TokenApiModel{ Token = tokenHandler.WriteToken(token)});
        }
    }
}