using Cashback.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cashback.WebApi.Controllers
{
    /// <summary>
    /// Relatórios
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReportController : CashbackBaseController
    {
        /// <summary>
        /// Rota para exibir o acumulado de cashback até o momento,
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        [Route("cashback/balance")]
        public async Task<IActionResult> Get([FromServices]IBalanceReportService reportService)
        {
            try
            {
                var balance = await reportService.GetRetailerBalance(User.Identity.Name);
                return Ok(balance);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}