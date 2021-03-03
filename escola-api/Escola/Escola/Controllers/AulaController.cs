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
    public class AulaController : ControllerBase
    {
        private readonly IAulaRepository _repo;

        public AulaController(IAulaRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<AulaController>
        [HttpGet]
        public IEnumerable<Aula> GetAll()
        {
            return _repo.SelecionarTudoCompleto();
        }

        // GET api/<AulaController>/5
        [HttpGet("{id}")]
        public Aula Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<AulaController>
        [HttpPost]
        public IEnumerable<Aula> Post([FromBody] Aula aula)
        {
            _repo.Incluir(aula);
            return _repo.SelecionarTudo();
        }

        // PUT api/<AulaController>/5
        [HttpPut("{id}")]
        public IEnumerable<Aula> Put(int id, [FromBody] Aula aula)
        {
            _repo.Alterar(aula);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<AulaController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Aula> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
