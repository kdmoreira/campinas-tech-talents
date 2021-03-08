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
    public class BalancoMensalController : ControllerBase
    {
        private readonly IBalancoMensalRepository _repo;

        public BalancoMensalController(IBalancoMensalRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os balanços mensais registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/balancomensal
        /// </remarks>
        /// <response code="200">Retorna todos os balanços mensais.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET: api/<BalancoMensalController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }
        }

        /// <summary>
        /// Retorna um balanço mensal pelo id.
        /// </summary>
        /// <param name="id">Identificador do balanço mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/balancomensal/id
        /// </remarks>
        /// <response code="200">Retorna o balanço mensal com o identificador informado.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET api/<BalancoMensalController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repo.Selecionar(id));
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }
        }

        /// <summary>
        /// Inclui um novo balanço mensal.
        /// </summary>
        /// <param name="balancoMensal">Dados do Balanço Mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/balancomensal
        /// </remarks>
        /// <response code="200">Retorna todos os balanços mensais após a inclusão.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // POST api/<BalancoMensalController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] BalancoMensal balancoMensal)
        {
            try
            {
                _repo.Incluir(balancoMensal);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do balanço mensal pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do Balanço Mensal.</param>
        /// <param name="balancoMensal">Dados do Balanço Mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/balancomensal/id
        /// </remarks>
        /// <response code="200">Altera os dados do Balanço Mensal.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // PUT api/<BalancoMensalController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] BalancoMensal balancoMensal)
        {
            try
            {
                _repo.Alterar(balancoMensal);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }
        }

        /// <summary>
        /// Deleta um Balanco Mensal pelo id.
        /// </summary>
        /// <param name="id">Identificador do Balanco Mensal.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Balanco Mensal/id
        /// </remarks>
        /// <response code="200">Retorna todos os Balanco Mensals.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // DELETE api/<Balanco MensalController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
                return BadRequest("Aconteceu um erro");
            }
        }
    }
}
