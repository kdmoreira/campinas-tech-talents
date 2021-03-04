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
    public class TurmaAlunoController : ControllerBase
    {
        private readonly ITurmaAlunoRepository _repo;

        public TurmaAlunoController(ITurmaAlunoRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<TurmaAlunoController>
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

        // GET api/<TurmaAlunoController>/5
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

        // POST api/<TurmaAlunoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] TurmaAluno turmaAluno)
        {
            try
            {
                _repo.Incluir(turmaAluno);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }
            
        }

        // PUT api/<TurmaAlunoController>/5
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] TurmaAluno turmaAluno)
        {
            try
            {
                _repo.Alterar(turmaAluno);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }         
        }

        // DELETE api/<TurmaAlunoController>/5
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
