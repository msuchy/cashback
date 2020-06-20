using System.Net;
using Cashback.WebApi.Models.Retailers;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.WebApi.Controllers
{
    /// <summary>
    /// Revendedores
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RetailerController : ControllerBase
    {
        /// <summary>
        /// Rota para cadastrar um novo revendedor(a) exigindo no mínimo nome completo, CPF, e- mail e senha;
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200">Revendedor cadastrado com sucesso</response>
        /// <response code="400">Erro de validação dos dados enviados</response>
        [HttpPost]
        public IActionResult Post([FromBody]CreateRetailerApiModel request)
        {
            return Ok();
        }
    }
}