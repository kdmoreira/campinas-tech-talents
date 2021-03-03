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
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repo;

        public ProfessorController(IProfessorRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IEnumerable<Professor> GetAll()
        {
            return _repo.SelecionarTudoCompleto();
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public Professor Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IEnumerable<Professor> Post([FromBody] Professor professor)
        {
            _repo.Incluir(professor);
            return _repo.SelecionarTudo();
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IEnumerable<Professor> Put(int id, [FromBody] Professor professor)
        {
            _repo.Alterar(professor);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Professor> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
