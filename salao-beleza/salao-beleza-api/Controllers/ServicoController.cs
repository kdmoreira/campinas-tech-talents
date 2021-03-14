using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using salao_beleza_dominio;
using salao_beleza_data.Interface;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace salao_beleza_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Authorize(Roles = "Administrador")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository _repo;

        public ServicoController(IServicoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Serviços registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Servico
        /// </remarks>
        /// <response code="200">Retorna todos os Serviços.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<ServicoController>
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
        /// Retorna um Serviço pelo id.
        /// </summary>
        /// <param name="id">Identificador do Serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Servico/id
        /// </remarks>
        /// <response code="200">Retorna o Serviço com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<ServicoController>/5
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
        /// Inclui um novo Serviço.
        /// </summary>
        /// <param name="servico">Dados do Serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Servico
        /// </remarks>
        /// <response code="200">Retorna todos os Serviços.</response>
        /// <response code="400">Se Nome, MinutosParaExecução ou Preço não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<ServicoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Servico servico)
        {
            try
            {
                if (string.IsNullOrEmpty(servico.Nome) || servico.MinutosParaExecucao == 0 ||
                    servico.Preco == 0)
                    return BadRequest("Nome, MinutosParaExecução ou Preço não foram informados.");
                
                _repo.Incluir(servico);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Serviço pelo id informado.
        /// </summary>
        /// <param name="servico">Dados do Serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Servico/id
        /// </remarks>
        /// <response code="200">Altera os dados do Serviço.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<ServicoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] Servico servico)
        {
            try
            {
                if (!_repo.Encontrar(servico))
                    return NoContent();

                _repo.Alterar(servico);
                return Ok("Serviço alterado com sucesso!");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Serviço pelo id.
        /// </summary>
        /// <param name="id">Identificador do Serviço.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Servico/id
        /// </remarks>
        /// <response code="200">Retorna todos os Serviços.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<ServicoController>/5
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
