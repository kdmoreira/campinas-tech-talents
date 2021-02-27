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
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository repo;

        public AlunoController()
        {
            repo = new AlunoRepository();
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IEnumerable<Aluno> GetAll()
        {
            return repo.SelecionarTudo();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return repo.Selecionar(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public string Post([FromBody] Aluno aluno)
        {
            return repo.Incluir(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Aluno aluno)
        {
            return repo.Alterar(aluno);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Aluno> Delete(int id)
        {
            repo.Excluir(id);
            return repo.SelecionarTudo();
        }
    }
}
