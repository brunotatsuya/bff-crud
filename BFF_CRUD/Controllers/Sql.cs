using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BFF_CRUD.Models;
using BFF_CRUD.Services;

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
            return Ok("SELECT efetuado");
        }

        [Route("sql/insert")]
        [HttpPost]
        [Authorize]
        public IActionResult PerformInsert(DynamicStatement dynSt)
        {
            string statement = dynSt.statement.ToLower();
            if (!StatementValidationService.ValidateInsertStatement(statement))
                return BadRequest("O statement declarado não corresponde à estrutura de um comando INSERT.");
            return Ok("INSERT efetuado");
        }

        [Route("sql/update")]
        [HttpPut]
        [Authorize]
        public IActionResult PerformUpdate(DynamicStatement dynSt)
        {
            string statement = dynSt.statement.ToLower();
            if (!StatementValidationService.ValidateUpdateStatement(statement))
                return BadRequest("O statement declarado não corresponde à estrutura de um comando UPDATE com WHERE.");
            return Ok("UPDATE efetuado");
        }

        [Route("sql/delete")]
        [HttpDelete]
        [Authorize]
        public IActionResult PerformDelete(DynamicStatement dynSt)
        {
            string statement = dynSt.statement.ToLower();
            if (!StatementValidationService.ValidateDeleteStatement(statement))
                return BadRequest("O statement declarado não corresponde à estrutura de um comando DELETE com WHERE.");
            return Ok("DELETE efetuado");
        }
    }
}
