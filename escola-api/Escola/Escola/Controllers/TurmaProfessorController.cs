using Escola.Data.Repository;
using Escola.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Data.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaProfessorController : ControllerBase
    {
        private readonly ITurmaProfessorRepository _repo;

        public TurmaProfessorController(ITurmaProfessorRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todas as TurmaProfessor registradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/turmaprofessor
        /// </remarks>
        /// <response code="200">Retorna todas as TurmaProfessor.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<TurmaProfessorController>
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
        /// Retorna uma TurmaProfessor pelo id.
        /// </summary>
        /// <param name="id">Identificador da TurmaProfessor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/turmaprofessor/id
        /// </remarks>
        /// <response code="200">Retorna a TurmaProfessor com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<TurmaProfessorController>/5
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
        /// Inclui uma nova TurmaProfessor.
        /// </summary>
        /// <param name="turmaProfessor">Dados da TurmaProfessor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/turmaprofessor
        /// </remarks>
        /// <response code="200">Retorna todas as TurmaProfessor.</response>
        /// <response code="400">Se houver algum erro na inclusão.</response>
        // POST api/<TurmaProfessorController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] TurmaProfessor turmaProfessor)
        {
            try
            {
                _repo.Incluir(turmaProfessor);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro.");
            }
        }

        /// <summary>
        /// Altera os dados da TurmaProfessor pelo id informado.
        /// </summary>
        /// <param name="turmaProfessor">Dados da TurmaProfessor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/turmaprofessor/id
        /// </remarks>
        /// <response code="200">Altera os dados da TurmaProfessor.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<TurmaProfessorController>/5
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] TurmaProfessor turmaProfessor)
        {
            try
            {
                _repo.Alterar(turmaProfessor);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta uma TurmaProfessor pelo id.
        /// </summary>
        /// <param name="id">Identificador da TurmaProfessor.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/turmaprofessor/id
        /// </remarks>
        /// <response code="200">Retorna todas as TurmaProfessor.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<TurmaProfessorController>/5
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
