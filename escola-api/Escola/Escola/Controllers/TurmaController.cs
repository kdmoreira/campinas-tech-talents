using Microsoft.AspNetCore.Mvc;
using Escola.Data.Repository;
using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Data.Interface;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repo;
        // Caso queiramos monitorar nosso TurmaController (note no construtor também):
        private readonly ILogger _logger;

        public TurmaController(ITurmaRepository repo, ILogger<TurmaController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: api/<TurmaController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            // Uma recomendação é loggar o que importa, como as exceções
            try
            {
                return Ok(_repo.SelecionarTudoCompleto());
            }
            catch (System.Exception ex)
            {
                // Exemplo de uso do logger:
                _logger.LogError(ex, "Erro ao recuperar todas as turmas.");
                return BadRequest("Aconteceu um erro");
            }
        }

        // GET api/<TurmaController>/5
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

        // POST api/<TurmaController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Turma turma)
        {
            try
            {
                _repo.Incluir(turma);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }       
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Turma turma)
        {
            try
            {
                _repo.Alterar(turma);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }           
        }

        // DELETE api/<TurmaController>/5
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
