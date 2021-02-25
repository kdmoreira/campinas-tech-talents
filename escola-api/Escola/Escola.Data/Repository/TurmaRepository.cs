using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escola.Data.Repository
{
    public class TurmaRepository
    {
        private readonly Contexto contexto;
        public TurmaRepository()
        {
            contexto = new Contexto();
        }
        public void Incluir(Turma turma)
        {
            contexto.Turma.Add(turma);
            contexto.SaveChanges();
        }

        public Turma Selecionar(int id)
        {
            return contexto.Turma.FirstOrDefault(x => x.Id == id);
        }

        public List<Turma> SelecionarTudo()
        {
            return contexto.Turma.ToList();
        }

        public void Alterar(Turma turma)
        {
            contexto.Turma.Update(turma);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var turma = Selecionar(id);
            contexto.Turma.Remove(turma);
            contexto.SaveChanges();
        }
    }
}
