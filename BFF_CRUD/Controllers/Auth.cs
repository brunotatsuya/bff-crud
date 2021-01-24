using BFF_CRUD.Models;
using BFF_CRUD.Services;
using Microsoft.AspNetCore.Mvc;
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
            string stsAccessToken = STSAuthService.TrySTSAuthentication(credentials);
            if (string.IsNullOrEmpty(stsAccessToken))
            {
                return Unauthorized("As credenciais informadas não são válidas para autenticação STS.");
            }
            if (!(STSAuthService.ValidateGSIGroup(stsAccessToken, _configuration)))
            {
                return Unauthorized("As credenciais informadas não têm autorização para utilizar este serviço.");
            }
            var token = TokenService.GenerateToken(credentials, _configuration);
            return Ok(token);
        }
    }
}
