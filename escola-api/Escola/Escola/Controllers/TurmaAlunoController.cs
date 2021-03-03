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
        public IEnumerable<TurmaAluno> GetAll()
        {
            return _repo.SelecionarTudoCompleto();
        }

        // GET api/<TurmaAlunoController>/5
        [HttpGet("{id}")]
        public TurmaAluno Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<TurmaAlunoController>
        [HttpPost]
        public IEnumerable<TurmaAluno> Post([FromBody] TurmaAluno turmaAluno)
        {
            _repo.Incluir(turmaAluno);
            return _repo.SelecionarTudo();
        }

        // PUT api/<TurmaAlunoController>/5
        [HttpPut]
        public IEnumerable<TurmaAluno> Put([FromBody] TurmaAluno turmaAluno)
        {
            _repo.Alterar(turmaAluno);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<TurmaAlunoController>/5
        [HttpDelete("{id}")]
        public IEnumerable<TurmaAluno> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
