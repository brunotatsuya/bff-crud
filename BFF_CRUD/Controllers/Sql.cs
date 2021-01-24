using BFF_CRUD.Models;
using BFF_CRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BFF_CRUD.Controllers
{
    [ApiController]
    public class Sql : ControllerBase
    {
        [Route("sql/select")]
        [HttpPost]
        [Authorize]
        public IActionResult PerformSelect(DynamicStatement dynSt)
        {
            string statement = dynSt.statement.ToLower();
            if (!StatementValidationService.ValidateSelectStatement(statement))
                return BadRequest("O statement declarado não corresponde à estrutura de um comando SELECT.");
            string executionResult = DataAccessService.performQuery(statement);
            if (executionResult.Contains("Falha na execução: "))
                return BadRequest(executionResult);
            return Ok(executionResult);
        }

        [Route("sql/insert")]
        [HttpPost]
        [Authorize]
        public IActionResult PerformInsert(DynamicStatement dynSt)
        {
            string statement = dynSt.statement.ToLower();
            if (!StatementValidationService.ValidateInsertStatement(statement))
                return BadRequest("O statement declarado não corresponde à estrutura de um comando INSERT.");
            string executionResult = DataAccessService.performNonQuery(statement);
            if (executionResult.Contains("Falha na execução: "))
                return BadRequest(executionResult);
            return Ok(executionResult);
        }

        [Route("sql/update")]
        [HttpPut]
        [Authorize]
        public IActionResult PerformUpdate(DynamicStatement dynSt)
        {
            string statement = dynSt.statement.ToLower();
            if (!StatementValidationService.ValidateUpdateStatement(statement))
                return BadRequest("O statement declarado não corresponde à estrutura de um comando UPDATE com WHERE.");
            string executionResult = DataAccessService.performNonQuery(statement);
            if (executionResult.Contains("Falha na execução: "))
                return BadRequest(executionResult);
            return Ok(executionResult);
        }

        [Route("sql/delete")]
        [HttpDelete]
        [Authorize]
        public IActionResult PerformDelete(DynamicStatement dynSt)
        {
            string statement = dynSt.statement.ToLower();
            if (!StatementValidationService.ValidateDeleteStatement(statement))
                return BadRequest("O statement declarado não corresponde à estrutura de um comando DELETE com WHERE.");
            string executionResult = DataAccessService.performNonQuery(statement);
            if (executionResult.Contains("Falha na execução: "))
                return BadRequest(executionResult);
            return Ok(executionResult);
        }
    }
}
