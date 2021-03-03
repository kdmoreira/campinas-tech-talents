using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escola.Data.Repository
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Professor> SelecionarTudoCompleto()
        {
            return _contexto.Professor
                .Include(x => x.TurmaProfessor)
                .Include(x => x.Aulas)
                .ToList();
        }
    }
}
