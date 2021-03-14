using Escola.Data.Interface;
using Escola.Data.Repository;
using Escola.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // Aqui o controller todo precisa de autorização
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repo;

        public AlunoController(IAlunoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os alunos registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aluno
        /// </remarks>
        /// <response code="200">Retorna todos os alunos.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<AlunoController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        //[Authorize] // É possível aplicar autorização apenas para métodos também
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.SelecionarTudoCompleto());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // Selecionando alunos pelo nome
        [HttpGet("/nome")]
        public IActionResult ByName([FromBody] string nome)
        {
            try
            {
                return Ok(_repo.SelecionarNome(nome));
            }
            catch (System.Exception)
            {
                return BadRequest("Bad request");
            }
        }

        // Selecionando alunos pelo Email
        [HttpGet("/email")]
        public IActionResult ByEmail(string email)
        {
            try
            {
                return Ok(_repo.SelecionarEmail(email));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna um aluno pelo id.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aluno/id
        /// </remarks>
        /// <response code="200">Retorna o aluno com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [AllowAnonymous] // Mesmo com a controller pedindo autorização,
        // é possível liberar alguns métodos específicos
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.Selecionar(id));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Inclui um novo aluno.
        /// </summary>
        /// <param name="aluno">Dados do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/aluno
        /// </remarks>
        /// <response code="200">Retorna todos os alunos.</response>
        /// <response code="400">Se CPF ou Nome não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<AlunoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = "marketing,manager")] // Se alguém não autorizado tentar acessar, ocorrerá um Forbidden
        // Também serve para a controller inteira
        public IActionResult Post([FromBody] Aluno aluno)
        {
            try
            {
                if (string.IsNullOrEmpty(aluno.Cpf) || string.IsNullOrEmpty(aluno.Nome))
                    return BadRequest("Cpf ou Nome não foram informados.");
                _repo.IncluirAluno(aluno);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do aluno pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <param name="aluno">Dados do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/aluno/id
        /// </remarks>
        /// <response code="200">Altera os dados do aluno.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
            try
            {
                _repo.AlterarAluno(aluno);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um aluno pelo id.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/aluno/id
        /// </remarks>
        /// <response code="200">Retorna todos os alunos.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Excluir(id);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
