using Cashback.WebApi.Models.Auth;
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
        /// <summary>
        /// Rota para validar um login de um revendedor(a);
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromBody]LoginApiModel request)
        {
            return Ok(new TokenApiModel());
        }
    }
}