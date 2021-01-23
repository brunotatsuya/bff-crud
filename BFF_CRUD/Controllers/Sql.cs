using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BFF_CRUD.Models;

namespace BFF_CRUD.Controllers
{
    [Route("sql/select")]
    [ApiController]
    [Authorize]
    public class Sql : ControllerBase
    {
        [HttpPost]
        public IActionResult PerformSelect(SelectQuery selectQuery)
        {
            return Ok("token válido");
        }
    }
}
