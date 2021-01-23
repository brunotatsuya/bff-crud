using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BFF_CRUD.Models;
using BFF_CRUD.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BFF_CRUD.Controllers
{
    [Route("auth/request_token")]
    [ApiController]
    public class Auth : ControllerBase
    {
        // POST api/<auth>
        [HttpPost]
        public IActionResult RequestToken(Credentials credentials)
        {
            if (credentials.user == "tatsuya" && credentials.password == "1217")
            {
                var token = TokenService.GenerateToken(credentials);
                return Ok(token);
            } else
            {
                return Unauthorized("credenciais inválidas");
            }
        }

    }
}
