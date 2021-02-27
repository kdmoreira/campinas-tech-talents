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
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaAlunoController : ControllerBase
    {
        private readonly TurmaAlunoRepository repo;

        public TurmaAlunoController()
        {
            repo = new TurmaAlunoRepository();
        }

        // GET: api/<TurmaAlunoController>
        [HttpGet]
        public IEnumerable<TurmaAluno> GetAll()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<TurmaAlunoController>/5
        [HttpGet("{id}")]
        public TurmaAluno Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<TurmaAlunoController>
        [HttpPost]
        public IEnumerable<TurmaAluno> Post([FromBody] TurmaAluno turmaAluno)
        {
            repo.Incluir(turmaAluno);
            return repo.SelecionarTudo();
        }

        // PUT api/<TurmaAlunoController>/5
        [HttpPut]
        public IEnumerable<TurmaAluno> Put([FromBody] TurmaAluno turmaAluno)
        {
            repo.Alterar(turmaAluno);
            return repo.SelecionarTudo();
        }

        // DELETE api/<TurmaAlunoController>/5
        [HttpDelete("{id}")]
        public IEnumerable<TurmaAluno> Delete(int id)
        {
            repo.Excluir(id);
            return repo.SelecionarTudo();
        }
    }
}
