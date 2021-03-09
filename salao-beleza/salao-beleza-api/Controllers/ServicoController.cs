using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using salao_beleza_dominio;
using salao_beleza_data.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace salao_beleza_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository _repo;

        public ServicoController(IServicoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os serviços registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/servico
        /// </remarks>
        /// <response code="200">Retorna todos os serviços.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET: api/<ServicoController>
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
        /// Retorna um serviço pelo id.
        /// </summary>
        /// <param name="id">Identificador do serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/servico/id
        /// </remarks>
        /// <response code="200">Retorna o serviço com o identificador informado.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET api/<ServicoController>/5
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
        /// Inclui um novo serviço.
        /// </summary>
        /// <param name="servico">Dados do serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/servico
        /// </remarks>
        /// <response code="200">Retorna todos os serviços após a inclusão.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // POST api/<ServicoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Servico servico)
        {
            try
            {
                _repo.Incluir(servico);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do serviço pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do serviço.</param>
        /// <param name="Servico">Dados do serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/servico/id
        /// </remarks>
        /// <response code="200">Altera os dados do serviço.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // PUT api/<ServicoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Servico servico)
        {
            try
            {
                _repo.Alterar(servico);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }
        }

        /// <summary>
        /// Deleta um serviço pelo id.
        /// </summary>
        /// <param name="id">Identificador do serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/servico/id
        /// </remarks>
        /// <response code="200">Retorna todos os serviços.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // DELETE api/<ServicoController>/5
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
