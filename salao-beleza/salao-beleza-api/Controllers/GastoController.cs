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
    public class GastoController : ControllerBase
    {
        private readonly IGastoRepository _repo;

        public GastoController(IGastoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Gastos registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Gasto
        /// </remarks>
        /// <response code="200">Retorna todos os Gastos.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<GastoController>
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
        /// Retorna um Gasto pelo id.
        /// </summary>
        /// <param name="id">Identificador do Gasto.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Gasto/id
        /// </remarks>
        /// <response code="200">Retorna o Gasto com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<GastoController>/5
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
        /// Inclui um novo Gasto.
        /// </summary>
        /// <param name="gasto">Dados do Gasto.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Gasto
        /// </remarks>
        /// <response code="200">Retorna todos os Gastos.</response>
        /// <response code="400">Se data não for informada.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<GastoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Gasto gasto)
        {
            try
            {
                _repo.Incluir(gasto);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Gasto pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do Gasto.</param>
        /// <param name="gasto">Dados do Gasto.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Gasto/id
        /// </remarks>
        /// <response code="200">Altera os dados do Gasto.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<GastoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Gasto gasto)
        {
            try
            {
                _repo.Alterar(gasto);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Gasto pelo id.
        /// </summary>
        /// <param name="id">Identificador do Gasto.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Gasto/id
        /// </remarks>
        /// <response code="200">Retorna todos os Gastos.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<GastoController>/5
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
