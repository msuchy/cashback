using Cashback.WebApi.Models.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ReportController : ControllerBase
    {
        /// <summary>
        /// Rota para exibir o acumulado de cashback até o momento,
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        [Route("cashback/balance")]
        public IActionResult Get()
        {
            return Ok(new BalanceApiModel());
        }

    }
}