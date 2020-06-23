using Cashback.Domain.Dtos.Orders;
using Cashback.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// <param name="orderService"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateOrderDto request, [FromServices]IOrderService orderService)
        {
            try
            {
                await orderService.Create(request, User.Identity.Name);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Rota para listar as compras cadastradas
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Get([FromServices]IOrderService orderService)
        {
            var list = await orderService.List(User.Identity.Name);
            return Ok(list);
        }

    }
}