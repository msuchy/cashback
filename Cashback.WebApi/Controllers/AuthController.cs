using Cashback.Domain.Dtos.Auth;
using Cashback.Domain.Services;
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
    public class AuthController : CashbackBaseController
    {
        /// <summary>
        /// Rota para validar um login de um revendedor(a);
        /// </summary>
        /// <param name="request"></param>
        /// <param name="authService"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginDto request, [FromServices] IAuthService authService)
        {
            var token = await authService.Login(request);
            if (token == null)
                return BadRequest("Authentication failure");

            return Ok(token);
        }
    }
}