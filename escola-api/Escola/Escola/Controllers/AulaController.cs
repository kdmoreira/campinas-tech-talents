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
    public class AulaController : ControllerBase
    {
        private readonly IAulaRepository _repo;

        public AulaController(IAulaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todas as aulas registradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aula
        /// </remarks>
        /// <response code="200">Retorna todas as aulas.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<AulaController>
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
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna uma aula pelo id.
        /// </summary>
        /// <param name="id">Identificador da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/aula/id
        /// </remarks>
        /// <response code="200">Retorna a aula com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<AulaController>/5
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
        /// Inclui uma nova aula.
        /// </summary>
        /// <param name="aula">Dados da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/aula
        /// </remarks>
        /// <response code="200">Retorna todas as aulas.</response>
        /// <response code="400">Se o Assunto da aula não for informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<AulaController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Aula aula)
        {
            try
            {
                if (string.IsNullOrEmpty(aula.Assunto))
                    return BadRequest("Assunto da aula não foi informado.");
                _repo.Incluir(aula);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados da aula pelo id informado.
        /// </summary>
        /// <param name="id">Identificador da aula.</param>
        /// <param name="aula">Dados da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/aula/id
        /// </remarks>
        /// <response code="200">Altera a aula.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<AulaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Aula aula)
        {
            try
            {
                _repo.Alterar(aula);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta uma aula pelo id.
        /// </summary>
        /// <param name="id">Identificador da aula.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/aula/id
        /// </remarks>
        /// <response code="200">Retorna todas as aulas.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<AulaController>/5
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
