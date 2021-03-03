using Escola.Data.Interface;
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
        private readonly IAlunoRepository _alunoRepo;
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
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Info Log --- GET!");
            _logger.LogWarning("Warning Log --- GET!");
            _logger.LogCritical("Critical Log --- GET!");
            _logger.LogError("Error Log --- GET!");
            _logger.LogDebug("Debug Log --- GET!");

            return "";
        }
    }
}
