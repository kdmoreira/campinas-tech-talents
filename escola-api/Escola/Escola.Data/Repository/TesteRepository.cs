using Escola.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class TesteRepository : ITesteRepository
    {
        private readonly Guid _guid;
        private readonly IAlunoRepository _alunoRepo;
        private readonly ITurmaRepository _turmaRepo;

        public TesteRepository(IAlunoRepository alunoRepo, ITurmaRepository turmaRepo)
        {
            _guid = Guid.NewGuid();
            _alunoRepo = alunoRepo;
            _turmaRepo = turmaRepo;
        }
    }
}
