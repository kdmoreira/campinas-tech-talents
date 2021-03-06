using Escola.Data.Interface;
using Escola.Domain;
using Escola.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;

        // Testando o Logger:
        
        /* private readonly IAlunoRepository _alunoRepo;
        private readonly ITurmaRepository _turmaRepo;
        private readonly IProfessorRepository _professorRepo;
        private readonly ITesteRepository _testeRepo;
        private readonly ITesteSingletonRepository _testeSingletonRepo;
        private readonly ILogger _logger;

        public HomeController(IAlunoRepository alunoRepo, ITurmaRepository turmaRepo,
            IProfessorRepository professorRepo, ITesteRepository testeRepo,
            ITesteSingletonRepository testeSingletonRepo, ILogger<HomeController> logger)
        {
            _alunoRepo = alunoRepo;
            _turmaRepo = turmaRepo;
            _professorRepo = professorRepo;
            _testeRepo = testeRepo;
            _testeSingletonRepo = testeSingletonRepo;
            _logger = logger;
        } */

        public HomeController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        // Método referente ao logger:
        /*
        [HttpGet]
        public string GetLogger()
        {
            _logger.LogInformation("Info Log --- GET!");
            _logger.LogWarning("Warning Log --- GET!");
            _logger.LogCritical("Critical Log --- GET!");
            _logger.LogError("Error Log --- GET!");
            _logger.LogDebug("Debug Log --- GET!");

            return "";
        }
        */

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuarioDto)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarioDto.Nome) || string.IsNullOrEmpty(usuarioDto.Senha))
                    return BadRequest("Nome e/ou senha não devem ser nulos.");

                var usuario = _usuarioRepo.SelecionarPorNomeESenha(usuarioDto.Nome, usuarioDto.Senha);
                if (usuario == null)
                    return NotFound("Nome e/ou senha inválidos.");

                var token = TokenService.GerarToken(usuario);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            
        }
    }
}
