using Cashback.Domain.Dtos.Retailers;
using Cashback.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.WebApi.Controllers
{
    /// <summary>
    /// Revendedores
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RetailerController : CashbackBaseController
    {
        /// <summary>
        /// Rota para cadastrar um novo revendedor(a) exigindo no mínimo nome completo, CPF, e- mail e senha;
        /// </summary>
        /// <param name="request"></param>
        /// <param name="retailerService"></param>
        /// <response code="200">Revendedor cadastrado com sucesso</response>
        /// <response code="400">Erro de validação dos dados enviados</response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]CreateRetailerDto request, [FromServices]IRetailerService retailerService)
        {
            retailerService.Create(request);
            return Ok();
        }
    }
}