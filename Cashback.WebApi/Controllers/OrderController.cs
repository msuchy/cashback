using Cashback.Domain.Dtos.Orders;
using Cashback.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
        /// <param name="orderService"></param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost]
        public IActionResult Post([FromBody]CreateOrderDto request, [FromServices]IOrderService orderService)
        {
            try
            {
                return Ok(orderService.Create(request, User.Identity.Name));
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
        public IActionResult Get()
        {
            return Ok(new List<OrderDetailsDto>());
        }

    }
}