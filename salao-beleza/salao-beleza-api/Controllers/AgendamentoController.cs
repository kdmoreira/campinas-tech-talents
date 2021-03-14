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
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _repo;

        public AgendamentoController(IAgendamentoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Agendamentos registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Agendamento
        /// </remarks>
        /// <response code="200">Retorna todos os Agendamentos.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<AgendamentoController>
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
        /// Retorna um Agendamento pelo id.
        /// </summary>
        /// <param name="id">Identificador do Agendamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Agendamento/id
        /// </remarks>
        /// <response code="200">Retorna o Agendamento com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<AgendamentoController>/5
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
        /// Inclui um novo Agendamento.
        /// </summary>
        /// <param name="agendamento">Dados do Agendamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Agendamento
        /// </remarks>
        /// <response code="200">Retorna todos os Agendamentos.</response>
        /// <response code="400">Se data não for informada.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<AgendamentoController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Agendamento agendamento)
        {
            try
            {
                _repo.Incluir(agendamento);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Agendamento pelo id informado.
        /// </summary>
        /// <param name="id">Identificador do Agendamento.</param>
        /// <param name="agendamento">Dados do Agendamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Agendamento/id
        /// </remarks>
        /// <response code="200">Altera os dados do Agendamento.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<AgendamentoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody] Agendamento agendamento)
        {
            try
            {
                _repo.Alterar(agendamento);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Agendamento pelo id.
        /// </summary>
        /// <param name="id">Identificador do Agendamento.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Agendamento/id
        /// </remarks>
        /// <response code="200">Retorna todos os Agendamentos.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<AgendamentoController>/5
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
