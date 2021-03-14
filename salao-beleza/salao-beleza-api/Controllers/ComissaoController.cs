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
    public class ComissaoController : ControllerBase
    {
        private readonly IComissaoRepository _repo;

        public ComissaoController(IComissaoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todas as Comissões registradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Comissao
        /// </remarks>
        /// <response code="200">Retorna todas as Comissões.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<ComissaoController>
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
        /// Retorna uma Comissão pelo id.
        /// </summary>
        /// <param name="id">Identificador da Comissão.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Comissao/id
        /// </remarks>
        /// <response code="200">Retorna a Comissão com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<ComissaoController>/5
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
        /// Inclui uma nova Comissão.
        /// </summary>
        /// <param name="comissao">Dados da Comissão.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Comissao
        /// </remarks>
        /// <response code="200">Retorna todas as Comissões.</response>
        /// <response code="400">Se Valor não for informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<ComissaoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Comissao comissao)
        {
            try
            {
                if (comissao.Valor == 0)
                    return BadRequest("Valor não foi informado.");
                _repo.Incluir(comissao);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados da Comissão pelo id informado.
        /// </summary>
        /// <param name="id">Identificador da Comissão.</param>
        /// <param name="comissao">Dados da Comissão.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Comissao/id
        /// </remarks>
        /// <response code="200">Altera os dados da Comissão.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<ComissaoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Comissao comissao)
        {
            try
            {
                _repo.Alterar(comissao);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta uma Comissão pelo id.
        /// </summary>
        /// <param name="id">Identificador da Comissão.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Comissao/id
        /// </remarks>
        /// <response code="200">Retorna todas as Comissões.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<ComissaoController>/5
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
