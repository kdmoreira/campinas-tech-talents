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
        public IEnumerable<Turma> GetAll()
        {
            // Uma recomendação é loggar o que importa, como as exceções
            try
            {
                // throw new System.Exception();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Erro ao recuperar todas as turmas.");
            }
            return _repo.SelecionarTudoCompleto();
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public Turma Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<TurmaController>
        [HttpPost]
        public IEnumerable<Turma> Post([FromBody] Turma turma)
        {
            _repo.Incluir(turma);
            return _repo.SelecionarTudo();
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public IEnumerable<Turma> Put(int id, [FromBody] Turma turma)
        {
            _repo.Alterar(turma);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Turma> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
