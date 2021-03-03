using Escola.Data.Interface;
using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class AulaRepository : BaseRepository<Aula>, IAulaRepository
    {
        public AulaRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Aula> SelecionarTudoCompleto()
        {
            return _contexto.Aula
                .Include(x => x.Professor)
                .Include(x => x.Turma)
                .ToList();
        }
    }
}
