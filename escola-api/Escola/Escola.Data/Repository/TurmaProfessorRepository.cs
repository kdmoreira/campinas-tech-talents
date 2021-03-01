using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class TurmaProfessorRepository : BaseRepository<TurmaProfessor>
    {
        public List<TurmaProfessor> SelecionarTudoCompleto()
        {
            return contexto.TurmaProfessor
                .Include(x => x.Professor)
                .Include(x => x.Turma)
                .ToList();
        }
    }
}
