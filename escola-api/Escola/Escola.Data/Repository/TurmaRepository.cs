using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escola.Data.Repository
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Turma> SelecionarTudoCompleto()
        {
            return _contexto.Turma
                .Include(x => x.TurmaProfessor)
                .Include(x => x.TurmaAluno)
                .Include(x => x.Aulas)
                .ToList();
        }
    }
}
