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
        public IEnumerable<TurmaProfessor> GetAll()
        {
            return _repo.SelecionarTudoCompleto();
        }

        // GET api/<TurmaProfessorController>/5
        [HttpGet("{id}")]
        public TurmaProfessor Get(int id)
        {
            return _repo.Selecionar(id);
        }

        // POST api/<TurmaProfessorController>
        [HttpPost]
        public IEnumerable<TurmaProfessor> Post([FromBody] TurmaProfessor turmaProfessor)
        {
            _repo.Incluir(turmaProfessor);
            return _repo.SelecionarTudo();
        }

        // PUT api/<TurmaProfessorController>/5
        [HttpPut]
        public IEnumerable<TurmaProfessor> Put([FromBody] TurmaProfessor turmaProfessor)
        {
            _repo.Alterar(turmaProfessor);
            return _repo.SelecionarTudo();
        }

        // DELETE api/<TurmaProfessorController>/5
        [HttpDelete("{id}")]
        public IEnumerable<TurmaProfessor> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
