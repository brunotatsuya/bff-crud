using BFF_CRUD.Models;
using BFF_CRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BFF_CRUD.Controllers
{
    [ApiController]
    [Authorize]
    public class Statement : ControllerBase
    {
        private IConfiguration _configuration;

        public Statement(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        private IActionResult PerformHelper(DynamicStatement dynSt, string verb)
        {
            if (!RulesValidationService.ValidateTargetEnviroment(dynSt))
                return BadRequest("O ambiente informado é inválido.");
            if (!RulesValidationService.ValidateTargetDatabase(dynSt, _configuration))
                return BadRequest("O banco de dados informado não é acessível por este serviço.");
            if (!RulesValidationService.ValidateStatement(dynSt, verb))
                return BadRequest("O statement declarado não corresponde a um comando " + verb + " válido.");
            string executionResult = DataAccessService.performStatement(dynSt, verb, _configuration);
            if (executionResult.Contains("Falha na execução: "))
                return BadRequest(executionResult);
            return Ok(executionResult);
        }

        [Route("select")]
        [HttpPost]
        public IActionResult PerformSelect(DynamicStatement dynSt)
        {
            return PerformHelper(dynSt, "SELECT");
        }

        [Route("insert")]
        [HttpPost]
        public IActionResult PerformInsert(DynamicStatement dynSt)
        {
            return PerformHelper(dynSt, "INSERT");
        }

        [Route("update")]
        [HttpPut]
        public IActionResult PerformUpdate(DynamicStatement dynSt)
        {
            return PerformHelper(dynSt, "UPDATE");
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult PerformDelete(DynamicStatement dynSt)
        {
            return PerformHelper(dynSt, "DELETE");
        }
    }
}
