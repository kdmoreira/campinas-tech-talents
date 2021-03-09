using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        public UsuarioController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo ?? throw new ArgumentNullException("UsuarioRepository não pode ser nulo");
        }

        /// <summary>
        /// Inclui um novo usuário.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// Get/api/usuario
        /// </remarks>
        /// <response code="200">Registra o usuário.</response>
        /// <response code="400">Se Nome ou Senha não forem informados.</response>
        /// <response code="500">Erro do servidor.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Senha))
                    return BadRequest("Nome ou Senha não foram informados.");
                _usuarioRepo.Incluir(usuario);
                return Ok("Usuário salvo com sucesso!");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
