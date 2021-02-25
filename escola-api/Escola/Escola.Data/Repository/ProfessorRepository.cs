using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Escola.Data.Repository
{
    public class ProfessorRepository
    {
        private readonly Contexto contexto;
        public ProfessorRepository()
        {
            contexto = new Contexto();
        }
        public void Incluir(Professor professor)
        {
            contexto.Professor.Add(professor);
            contexto.SaveChanges();
        }

        public Professor Selecionar(int id)
        {
            return contexto.Professor.FirstOrDefault(x => x.Id == id);
        }

        public List<Professor> SelecionarTudo()
        {
            return contexto.Professor.ToList();
        }

        public void Alterar(Professor professor)
        {
            contexto.Professor.Update(professor);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var professor = Selecionar(id);
            contexto.Professor.Remove(professor);
            contexto.SaveChanges();
        }
    }
}
