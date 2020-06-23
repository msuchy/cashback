using Cashback.Domain.Dtos.Auth;
using Cashback.Domain.Services;
using Cashback.WebApi.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cashback.WebApi.Controllers
{
    /// <summary>
    /// Autenticação
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Rota para validar um login de um revendedor(a);
        /// </summary>
        /// <param name="request"></param>
        /// <param name="authService"></param>
        /// <param name="jwtTokenService"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginDto request, [FromServices] IAuthService authService, [FromServices] IJwtTokenService jwtTokenService)
        {
            if (await authService.Login(request))
                return Ok(new TokenDto { Token = jwtTokenService.CreateJwtToken(request.CPF) });
            else
                return BadRequest("Authentication failure");
        }
    }
}