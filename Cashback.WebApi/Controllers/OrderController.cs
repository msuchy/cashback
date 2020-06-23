using Cashback.Domain.Dtos.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cashback.WebApi.Controllers
{
    /// <summary>
    /// Compras
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderController : CashbackBaseController
    {

        /// <summary>
        /// Rota para cadastrar uma nova compra
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        public IActionResult Post([FromBody]CreateOrderDto request)
        {
            return Ok();
        }

        /// <summary>
        /// Rota para listar as compras cadastradas
        /// </summary>
        /// <response code="200"></response>

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            return Ok(new List<OrderDetailsDto>());
        }

    }
}