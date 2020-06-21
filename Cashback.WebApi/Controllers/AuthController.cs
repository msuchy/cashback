using System.Threading.Tasks;
using Cashback.Application;
using Cashback.Domain.Services;
using Cashback.WebApi.Models.Auth;
using Cashback.WebApi.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.WebApi.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }
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
        public async Task<IActionResult> Post([FromBody] LoginApiModel request, [FromServices] IAuthService authService, [FromServices] IJwtTokenService jwtTokenService)
        {
            if (await authService.Login(request.CPF, request.Password))
                return Ok(new TokenApiModel { Token = jwtTokenService.CreateJwtToken(request.CPF) });
            else
                return BadRequest("Authentication failure");
        }


    }
}