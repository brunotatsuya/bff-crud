using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BFF_CRUD.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BFF_CRUD.Controllers
{
    [Route("sql/select")]
    [ApiController]
    [Authorize]
    public class Sql : ControllerBase
    {
        // POST api/<sql>
        [HttpPost]
        public IActionResult PerformSelect(SelectQuery selectQuery)
        {
            return Ok("token válido");
        }
    }
}
