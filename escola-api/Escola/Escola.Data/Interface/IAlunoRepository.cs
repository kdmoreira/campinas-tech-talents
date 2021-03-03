using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Interface
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        List<Aluno> SelecionarTudoCompleto();
        string AlterarAluno(Aluno aluno);
        string IncluirAluno(Aluno aluno);
    }
}
