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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioController(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retorna todos os Usuários registrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Usuario
        /// </remarks>
        /// <response code="200">Retorna todos os Usuários.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET: api/<UsuarioController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _repo.SelecionarTudo();
                if (usuarios.Count < 1)
                    return NoContent();

                return Ok(usuarios);

            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna um Usuario pelo id.
        /// </summary>
        /// <param name="id">Identificador do Usuario.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/Usuario/id
        /// </remarks>
        /// <response code="200">Retorna o Usuario com o identificador informado.</response>
        /// <response code="500">Erro do servidor.</response>
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetById(int id)
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
        /// Inclui um novo Usuario.
        /// </summary>
        /// <param name="usuario">Dados do Usuario.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Post/api/Usuario
        /// </remarks>
        /// <response code="201">Usuário cadastrado com sucesso.</response>
        /// <response code="400">Se os campos obrigatórios não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        // POST api/<UsuarioController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.Nome) ||
                    string.IsNullOrEmpty(usuario.Email) ||
                    string.IsNullOrEmpty(usuario.Perfil) ||
                    string.IsNullOrEmpty(usuario.Senha))
                {
                    return BadRequest("Todos os campos são obrigatórios.");
                }

                _repo.Incluir(usuario);

                return Created("", "Usuário cadastrado com sucesso.");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera os dados do Usuario pelo id informado.
        /// </summary>
        /// <param name="usuario">Dados do Usuario.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Put/api/Usuario/id
        /// </remarks>
        /// <response code="200">Altera os dados do Usuario.</response>
        /// <response code="204">Usuário não encontrado.</response>
        /// <response code="500">Erro do servidor.</response>
        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            try
            {
                if (!_repo.Encontrar(usuario))
                    return NoContent();

                _repo.Alterar(usuario);
                return Ok("Usuário alterado com sucesso!");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um Usuario pelo id.
        /// </summary>
        /// <param name="id">Identificador do Usuario.</param>
        /// <remarks>
        /// Exemplo de request:
        /// Delete/api/Usuario/id
        /// </remarks>
        /// <response code="200">Remove o usuário.</response>
        /// <response code="204">Usuário não encontrado.</response>
        /// <response code="500">Erro do servidor.</response>
        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                var usuarioExiste = _repo.Selecionar(id);
                if (usuarioExiste == null)
                    return NoContent();

                _repo.Excluir(usuarioExiste.Id);

                return Ok("Usuário removido com sucesso.");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
