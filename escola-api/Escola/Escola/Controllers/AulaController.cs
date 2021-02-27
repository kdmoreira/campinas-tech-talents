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
        private readonly AulaRepository repo;

        public AulaController()
        {
            repo = new AulaRepository();
        }

        // GET: api/<AulaController>
        [HttpGet]
        public IEnumerable<Aula> GetAll()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<AulaController>/5
        [HttpGet("{id}")]
        public Aula Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<AulaController>
        [HttpPost]
        public IEnumerable<Aula> Post([FromBody] Aula aula)
        {
            repo.Incluir(aula);
            return repo.SelecionarTudo();
        }

        // PUT api/<AulaController>/5
        [HttpPut("{id}")]
        public IEnumerable<Aula> Put(int id, [FromBody] Aula aula)
        {
            repo.Alterar(aula);
            return repo.SelecionarTudo();
        }

        // DELETE api/<AulaController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Aula> Delete(int id)
        {
            repo.Excluir(id);
            return repo.SelecionarTudo();
        }
    }
}
