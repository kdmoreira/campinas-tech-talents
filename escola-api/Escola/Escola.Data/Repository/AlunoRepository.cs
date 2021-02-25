using Escola.Domain;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Data.Repository
{
    public class AlunoRepository
    {
        private readonly Contexto contexto;
        public AlunoRepository()
        {
            contexto = new Contexto();
        }
        public void Incluir(Aluno aluno)
        {
            contexto.Aluno.Add(aluno);
            contexto.SaveChanges();
        }

        public Aluno Selecionar(int id)
        {
            return contexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

        public List<Aluno> SelecionarTudo()
        {
            return contexto.Aluno.ToList();
        }

        public void Alterar(Aluno aluno)
        {
            contexto.Aluno.Update(aluno);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var aluno = Selecionar(id);
            contexto.Aluno.Remove(aluno);
            contexto.SaveChanges();
        }
    }
}
