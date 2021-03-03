using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Interface
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        List<Turma> SelecionarTudoCompleto();
    }
}
