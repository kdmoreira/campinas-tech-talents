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
    [Authorize(Roles = "Funcionario,Administrador")]
    public class ServicoSolicitadoController : ControllerBase
    {
        private readonly IServicoSolicitadoRepository _repo;

        public ServicoSolicitadoController(IServicoSolicitadoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Serviços Solicitados registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/ServicoSolicitado
        /// </remarks>
        /// <response code="200">Retorna todos os Serviços Solicitados.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<ServicoSolicitadoController>
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
        /// Retorna um Serviço Solicitado pelo id.
        /// </summary>
        /// <param name="id">Identificador do Serviço Solicitado.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/ServicoSolicitado/id
        /// </remarks>
        /// <response code="200">Retorna o Serviço Solicitado com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<ServicoSolicitadoController>/5
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
        /// Inclui um novo Serviço Solicitado.
        /// </summary>
        /// <param name="servicoSolicitado">Dados do Serviço Solicitado.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/ServicoSolicitado
        /// </remarks>
        /// <response code="200">Retorna todos os Serviços Solicitados.</response>
        /// <response code="400">Se data não for informada.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<ServicoSolicitadoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] ServicoSolicitado servicoSolicitado)
        {
            try
            {
                _repo.Incluir(servicoSolicitado);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Serviço Solicitado pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do Serviço Solicitado.</param>
        /// <param name="servicoSolicitado">Dados do Serviço Solicitado.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/ServicoSolicitado/id
        /// </remarks>
        /// <response code="200">Altera os dados do Serviço Solicitado.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<ServicoSolicitadoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] ServicoSolicitado servicoSolicitado)
        {
            try
            {
                _repo.Alterar(servicoSolicitado);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Serviço Solicitado pelo id.
        /// </summary>
        /// <param name="id">Identificador do Serviço Solicitado.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/ServicoSolicitado/id
        /// </remarks>
        /// <response code="200">Retorna todos os Serviços Solicitados.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<ServicoSolicitadoController>/5
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
