using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.WebApi.Controllers
{
    [Authorize]
    public class CashbackBaseController : ControllerBase
    {
    }
}