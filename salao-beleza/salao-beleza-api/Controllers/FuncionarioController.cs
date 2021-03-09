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
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _repo;

        public FuncionarioController(IFuncionarioRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os funcionários registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/funcionario
        /// </remarks>
        /// <response code="200">Retorna todos os funcionários.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET: api/<FuncionarioController>
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
        /// Retorna um funcionário pelo id.
        /// </summary>
        /// <param name="id">Identificador do funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/funcionario/id
        /// </remarks>
        /// <response code="200">Retorna o funcionário com o identificador informado.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // GET api/<FuncionarioController>/5
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
        /// Inclui um novo funcionário.
        /// </summary>
        /// <param name="funcionario">Dados do funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/funcionario
        /// </remarks>
        /// <response code="200">Retorna todos os funcionários após a inclusão.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // POST api/<FuncionarioController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                _repo.Incluir(funcionario);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do funcionário pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do funcionário.</param>
        /// <param name="funcionario">Dados do funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/funcionario/id
        /// </remarks>
        /// <response code="200">Altera os dados do funcionário.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Funcionario funcionario)
        {
            try
            {
                _repo.Alterar(funcionario);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest("Aconteceu um erro");
            }
        }

        /// <summary>
        /// Deleta um funcionário pelo id.
        /// </summary>
        /// <param name="id">Identificador do funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/funcionario/id
        /// </remarks>
        /// <response code="200">Retorna todos os funcionários.</response>
        /// <response code="400">Se acontecer alguma exceção não tratada.</response>
        // DELETE api/<FuncionarioController>/5
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
