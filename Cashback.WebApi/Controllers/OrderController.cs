using System.Collections.Generic;
using Cashback.WebApi.Models.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {

        /// <summary>
        /// Rota para cadastrar uma nova compra exigindo no mínimo código, valor, data e CPF do revendedor(a). Todos os cadastros são salvos com o status “Em validação” exceto quando o CPF do revendedor(a) for 153.509.460-56, neste caso o status é salvo como “Aprovado”;
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        public IActionResult Post([FromBody]CreateOrderApiModel request)
        {
            return Ok();
        }

        /// <summary>
        /// Rota para listar as compras cadastradas retornando código, valor, data, % de cashback aplicado para esta compra, valor de cashback para esta compra e status;
        /// </summary>
        /// <response code="200"></response>

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            return Ok(new List<OrderDetailsApiModel>());
        }

    }
}