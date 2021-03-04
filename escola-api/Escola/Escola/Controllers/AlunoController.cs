using Escola.Data.Interface;
using Escola.Data.Repository;
using Escola.Domain;
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
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET: api/<AlunoController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.SelecionarTudoCompleto());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
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
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.Selecionar(id));
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
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
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // POST api/<AlunoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            try
            {
                _repo.IncluirAluno(aluno);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
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
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
            try
            {
                return Ok(_repo.AlterarAluno(aluno));
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
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
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
                return BadRequest("Aconteceu um erro");
            }
        }
    }
}
