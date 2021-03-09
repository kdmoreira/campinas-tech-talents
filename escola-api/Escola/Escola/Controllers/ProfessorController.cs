using Escola.Data.Interface;
using Escola.Data.Repository;
using Escola.Domain;
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
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repo;

        public ProfessorController(IProfessorRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os professores registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/professor
        /// </remarks>
        /// <response code="200">Retorna todos os professores.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<ProfessorController>
        [HttpGet]
        [ProducesResponseType(200)]
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
        /// Retorna um professor pelo id.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/professor/id
        /// </remarks>
        /// <response code="200">Retorna o professor com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
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
        /// Inclui um novo professor.
        /// </summary>
        /// <param name="professor">Dados do professor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/professor
        /// </remarks>
        /// <response code="200">Retorna todos os professores.</response>
        /// <response code="400">Se o Nome ou Email do professor não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<ProfessorController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Professor professor)
        {
            try
            {
                if (string.IsNullOrEmpty(professor.Nome) || string.IsNullOrEmpty(professor.Email))
                    return BadRequest("Nome ou Email não foram informados.");
                _repo.Incluir(professor);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do professor pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <param name="professor">Dados do professor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/professor/id
        /// </remarks>
        /// <response code="200">Altera os dados do professor.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Professor professor)
        {
            try
            {
                _repo.Alterar(professor);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um professor pelo id.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/professor/id
        /// </remarks>
        /// <response code="200">Retorna todos os professores.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<ProfessorController>/5
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
