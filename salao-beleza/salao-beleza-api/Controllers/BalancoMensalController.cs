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
    public class BalancoMensalController : ControllerBase
    {
        private readonly IBalancoMensalRepository _repo;

        public BalancoMensalController(IBalancoMensalRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Balanços Mensais registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/BalancoMensal
        /// </remarks>
        /// <response code="200">Retorna todos os Balanços Mensais.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<BalancoMensalController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.SelecionarTudoCompleto());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna um Balanço Mensal pelo id.
        /// </summary>
        /// <param name="id">Identificador do Balanço Mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/BalancoMensal/id
        /// </remarks>
        /// <response code="200">Retorna o Balanço Mensal com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<BalancoMensalController>/5
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
        /// Inclui um novo Balanço Mensal.
        /// </summary>
        /// <param name="balancoMensal">Dados do Balanço Mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/BalancoMensal
        /// </remarks>
        /// <response code="200">Retorna todos os Balanços Mensais.</response>
        /// <response code="400">Se Mês ou Ano não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<BalancoMensalController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] BalancoMensal balancoMensal)
        {
            try
            {
                if (balancoMensal.Mes == 0 || balancoMensal.Ano == 0)
                    return BadRequest("Mês ou Ano não foram informados.");
                _repo.Incluir(balancoMensal);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Balanço Mensal pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do Balanço Mensal.</param>
        /// <param name="balancoMensal">Dados do Balanço Mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/BalancoMensal/id
        /// </remarks>
        /// <response code="200">Altera os dados do Balanço Mensal.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<BalancoMensalController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] BalancoMensal balancoMensal)
        {
            try
            {
                _repo.Alterar(balancoMensal);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Balanço Mensal pelo id.
        /// </summary>
        /// <param name="id">Identificador do Balanço Mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/BalancoMensal/id
        /// </remarks>
        /// <response code="200">Retorna todos os Balanços Mensais.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<BalancoMensalController>/5
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
