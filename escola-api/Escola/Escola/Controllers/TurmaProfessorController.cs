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

        // GET: api/<TurmaProfessorController>
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

        // GET api/<TurmaProfessorController>/5
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

        // POST api/<TurmaProfessorController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] TurmaProfessor turmaProfessor)
        {
            try
            {
                _repo.Incluir(turmaProfessor);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }
        }

        // PUT api/<TurmaProfessorController>/5
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
                return BadRequest("Aconteceu um erro");
            }
        }

        // DELETE api/<TurmaProfessorController>/5
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
