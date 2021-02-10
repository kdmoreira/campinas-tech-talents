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
    public class ServicoController : ControllerBase
    {
        private readonly BaseServicos baseServicos;

        public ServicoController()
        {
            baseServicos = new BaseServicos();
        }

        // GET: api/<ServicoController>
        [HttpGet]
        public IEnumerable<Servico> Get()
        {
            return baseServicos.Servicos;
        }

        // GET api/<ServicoController>/5
        [HttpGet("{id}")]
        public Servico Get(int id)
        {
            return baseServicos.ServicoPorId(id);
        }

        // POST api/<ServicoController>
        [HttpPost]
        public IEnumerable<Servico> Post([FromBody] Servico servico)
        {
            baseServicos.Incluir(servico);
            return baseServicos.Servicos;
        }

        // PUT api/<ServicoController>/5
        [HttpPut("{id}")]
        public IEnumerable<Servico> Put([FromBody] Servico servico)
        {
            baseServicos.AlterarServico(servico.Id, servico.Nome, servico.MinutosParaExecucao,
                servico.Preco);
            return baseServicos.Servicos;
        }

        // DELETE api/<ServicoController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Servico> Delete(int id)
        {
            baseServicos.ExcluirUmServico(id);
            return baseServicos.Servicos;
        }
    }
}
