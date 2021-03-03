using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Interface
{
    public interface IAulaRepository : IBaseRepository<Aula>
    {
        List<Aula> SelecionarTudoCompleto();
    }
}
