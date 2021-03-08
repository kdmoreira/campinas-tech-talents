using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using salao_beleza_dominio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace salao_beleza_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly BaseFuncionarios baseFuncionarios;

        public FuncionarioController()
        {
            baseFuncionarios = new BaseFuncionarios();
        }

        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            return baseFuncionarios.Funcionarios;
        }

        [HttpGet("{matricula}")]
        public Funcionario Get(int matricula)
        {
            return baseFuncionarios.FuncionarioPorMatricula(matricula);
        }

        [HttpPost]
        public IEnumerable<Funcionario> Post([FromBody] Funcionario funcionario)
        {
            baseFuncionarios.Incluir(funcionario);
            return baseFuncionarios.Funcionarios;
        }

        [HttpPut("{matricula}")]
        public IEnumerable<Funcionario> Put([FromBody] Funcionario funcionario)
        {
            baseFuncionarios.AlterarFuncionario(funcionario.Id, funcionario.Nome,
                funcionario.Telefone, funcionario.Endereco, funcionario.Cargo);
            return baseFuncionarios.Funcionarios ;
        }

        [HttpDelete("{matricula}")]
        public IEnumerable<Funcionario> Delete(int matricula)
        {
            baseFuncionarios.ExcluirFuncionario(matricula);
            return baseFuncionarios.Funcionarios;
        }
    }
}
