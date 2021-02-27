using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class TurmaAlunoRepository
    {
        private readonly Contexto contexto;
        public TurmaAlunoRepository()
        {
            contexto = new Contexto();
        }
        public void Incluir(TurmaAluno turmaAluno)
        {
            contexto.TurmaAluno.Add(turmaAluno);
            contexto.SaveChanges();
        }

        public TurmaAluno Selecionar(int id)
        {
            return contexto.TurmaAluno.FirstOrDefault(x => x.Id == id);
        }

        public List<TurmaAluno> SelecionarTudo()
        {
            return contexto.TurmaAluno.ToList();
        }

        public void Alterar(TurmaAluno turmaAluno)
        {
            contexto.TurmaAluno.Update(turmaAluno);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var turmaAluno = Selecionar(id);
            contexto.TurmaAluno.Remove(turmaAluno);
            contexto.SaveChanges();
        }
    }
}
