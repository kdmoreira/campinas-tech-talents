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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        public ClienteController(IClienteRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Clientes registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Cliente
        /// </remarks>
        /// <response code="200">Retorna todos os Clientes.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<ClienteController>
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
        /// Retorna um Cliente pelo id.
        /// </summary>
        /// <param name="id">Identificador do Cliente.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Cliente/id
        /// </remarks>
        /// <response code="200">Retorna o Cliente com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<ClienteController>/5
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
        /// Inclui um novo Cliente.
        /// </summary>
        /// <param name="cliente">Dados do Cliente.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Cliente
        /// </remarks>
        /// <response code="200">Retorna todos os Clientes.</response>
        /// <response code="400">Se Nome, CPF, Telefone ou Endereço não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.Cpf) ||
                    string.IsNullOrEmpty(cliente.Telefone) || string.IsNullOrEmpty(cliente.Endereco))
                    return BadRequest("Nome, Cpf, Telefone ou Endereço não foram informados.");

                if (cliente.Cpf.Length != 11)
                    return BadRequest("Cpf não foi informado corretamente, informe um Cpf com 11 dígitos.");

                _repo.Incluir(cliente);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Cliente pelo id informado.
        /// </summary>
        /// <param name="cliente">Dados do Cliente.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Cliente/id
        /// </remarks>
        /// <response code="200">Altera os dados do Cliente.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                if (!_repo.Encontrar(cliente))
                    return NoContent();

                _repo.Alterar(cliente);
                return Ok("Cliente alterado com sucesso!");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Cliente pelo id.
        /// </summary>
        /// <param name="id">Identificador do Cliente.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Cliente/id
        /// </remarks>
        /// <response code="200">Retorna todos os Clientes.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<ClienteController>/5
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
