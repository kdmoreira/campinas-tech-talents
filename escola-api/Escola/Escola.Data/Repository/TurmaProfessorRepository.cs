using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class TurmaProfessorRepository
    {
        private readonly Contexto contexto;
        public TurmaProfessorRepository()
        {
            contexto = new Contexto();
        }
        public void Incluir(TurmaProfessor turmaProfessor)
        {
            contexto.TurmaProfessor.Add(turmaProfessor);
            contexto.SaveChanges();
        }

        public TurmaProfessor Selecionar(int id)
        {
            return contexto.TurmaProfessor.FirstOrDefault(x => x.Id == id);
        }

        public List<TurmaProfessor> SelecionarTudo()
        {
            return contexto.TurmaProfessor.ToList();
        }

        public void Alterar(TurmaProfessor turmaProfessor)
        {
            contexto.TurmaProfessor.Update(turmaProfessor);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var turmaProfessor = Selecionar(id);
            contexto.TurmaProfessor.Remove(turmaProfessor);
            contexto.SaveChanges();
        }
    }
}
