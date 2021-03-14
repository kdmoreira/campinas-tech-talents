using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace salao_beleza_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Authorize(Roles = "Administrador")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepository _repo;

        public PagamentoController(IPagamentoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Pagamentos registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Pagamento
        /// </remarks>
        /// <response code="200">Retorna todos os Pagamentos.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<PagamentoController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna um Pagamento pelo id.
        /// </summary>
        /// <param name="id">Identificador do Pagamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Pagamento/id
        /// </remarks>
        /// <response code="200">Retorna o Pagamento com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<PagamentoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.Selecionar(id));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Inclui um novo Pagamento.
        /// </summary>
        /// <param name="pagamento">Dados do Pagamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Pagamento
        /// </remarks>
        /// <response code="200">Retorna todos os Pagamentos.</response>
        /// <response code="400">Se data não for informada.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<PagamentoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Pagamento pagamento)
        {
            try
            {
                _repo.Incluir(pagamento);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Pagamento pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do Pagamento.</param>
        /// <param name="pagamento">Dados do Pagamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Pagamento/id
        /// </remarks>
        /// <response code="200">Altera os dados do Pagamento.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<PagamentoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Pagamento pagamento)
        {
            try
            {
                _repo.Alterar(pagamento);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Pagamento pelo id.
        /// </summary>
        /// <param name="id">Identificador do Pagamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Pagamento/id
        /// </remarks>
        /// <response code="200">Retorna todos os Pagamentos.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<PagamentoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Excluir(id);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
