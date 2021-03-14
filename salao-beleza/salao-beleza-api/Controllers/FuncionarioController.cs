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
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _repo;

        public FuncionarioController(IFuncionarioRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Funcionários registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Funcionario
        /// </remarks>
        /// <response code="200">Retorna todos os Funcionários.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<FuncionarioController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.SelecionarTudoCompleto());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna um Funcionário pelo id.
        /// </summary>
        /// <param name="id">Identificador do Funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Funcionario/id
        /// </remarks>
        /// <response code="200">Retorna o Funcionário com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<FuncionarioController>/5
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
        /// Inclui um novo Funcionário.
        /// </summary>
        /// <param name="funcionario">Dados do Funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Funcionario
        /// </remarks>
        /// <response code="200">Retorna todos os Funcionários.</response>
        /// <response code="400">Se Nome, CPF, Telefone ou Endereço não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<FuncionarioController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                if (string.IsNullOrEmpty(funcionario.Nome) || string.IsNullOrEmpty(funcionario.Cpf) ||
                    string.IsNullOrEmpty(funcionario.Telefone) || string.IsNullOrEmpty(funcionario.Endereco))
                    return BadRequest("Nome, Cpf, Telefone ou Endereço não foram informados.");
                
                if (funcionario.Cpf.Length != 11)
                    return BadRequest("Cpf não foi informado corretamente, informe um Cpf com 11 dígitos.");
                
                _repo.Incluir(funcionario);
                return Ok(_repo.SelecionarTudo());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Funcionário pelo id informado.
        /// </summary>

        /// <param name="funcionario">Dados do Funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Funcionario/id
        /// </remarks>
        /// <response code="200">Altera os dados do Funcionário.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] Funcionario funcionario)
        {
            try
            {
                if (!_repo.Encontrar(funcionario))
                    return NoContent();

                _repo.Alterar(funcionario);
                return Ok("Funcionário alterado com sucesso!");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Funcionário pelo id.
        /// </summary>
        /// <param name="id">Identificador do Funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Funcionario/id
        /// </remarks>
        /// <response code="200">Retorna todos os Funcionários.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<FuncionarioController>/5
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
