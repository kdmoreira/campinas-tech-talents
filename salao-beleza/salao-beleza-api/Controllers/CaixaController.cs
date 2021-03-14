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
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaRepository _repo;

        public CaixaController(ICaixaRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Caixas registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Caixa
        /// </remarks>
        /// <response code="200">Retorna todos os Caixas.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<CaixaController>
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
        /// Retorna um Caixa pelo id.
        /// </summary>
        /// <param name="id">Identificador do Caixa.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Caixa/id
        /// </remarks>
        /// <response code="200">Retorna o Caixa com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<CaixaController>/5
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
        /// Inclui um novo Caixa.
        /// </summary>
        /// <param name="caixa">Dados do Caixa.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Caixa
        /// </remarks>
        /// <response code="200">Retorna todos os Caixas.</response>
        /// <response code="400">Se data não for informada.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<CaixaController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Caixa caixa)
        {
            try
            {
                _repo.Incluir(caixa);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Caixa pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do Caixa.</param>
        /// <param name="caixa">Dados do Caixa.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Caixa/id
        /// </remarks>
        /// <response code="200">Altera os dados do Caixa.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<CaixaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Caixa caixa)
        {
            try
            {
                _repo.Alterar(caixa);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Caixa pelo id.
        /// </summary>
        /// <param name="id">Identificador do Caixa.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Caixa/id
        /// </remarks>
        /// <response code="200">Retorna todos os Caixas.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<CaixaController>/5
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
