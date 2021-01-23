using Microsoft.AspNetCore.Mvc;
using BFF_CRUD.Models;
using BFF_CRUD.Services;
using Microsoft.Extensions.Configuration;

namespace BFF_CRUD.Controllers
{
    [Route("auth/request_token")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private IConfiguration _configuration;

        public Auth(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        [HttpPost]
        public IActionResult RequestToken(Credentials credentials)
        {
            if (credentials.user == "tatsuya" && credentials.password == "1217")
            {
                var token = TokenService.GenerateToken(credentials, _configuration);
                return Ok(token);
            } else
            {
                return Unauthorized("credenciais inválidas");
            }
        }

    }
}
