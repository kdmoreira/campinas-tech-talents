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

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepo.Incluir(usuario);
                return Ok("Usuário salvo com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
