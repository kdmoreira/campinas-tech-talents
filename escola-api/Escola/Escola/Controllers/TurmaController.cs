using Microsoft.AspNetCore.Mvc;
using Escola.Data.Repository;
using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaRepository repo;

        public TurmaController()
        {
            repo = new TurmaRepository();
        }

        // GET: api/<TurmaController>
        [HttpGet]
        public IEnumerable<Turma> GetAll()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public Turma Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<TurmaController>
        [HttpPost]
        public IEnumerable<Turma> Post([FromBody] Turma turma)
        {
            repo.Incluir(turma);
            return repo.SelecionarTudo();
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public IEnumerable<Turma> Put(int id, [FromBody] Turma turma)
        {
            repo.Alterar(turma);
            return repo.SelecionarTudo();
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Turma> Delete(int id)
        {
            repo.Excluir(id);
            return repo.SelecionarTudo();
        }
    }
}
