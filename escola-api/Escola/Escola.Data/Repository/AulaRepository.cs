using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class AulaRepository
    {
        private readonly Contexto contexto;
        public AulaRepository()
        {
            contexto = new Contexto();
        }
        public void Incluir(Aula aula)
        {
            contexto.Aula.Add(aula);
            contexto.SaveChanges();
        }

        public Aula Selecionar(int id)
        {
            return contexto.Aula.FirstOrDefault(x => x.Id == id);
        }

        public List<Aula> SelecionarTudo()
        {
            return contexto.Aula.ToList();
        }

        public void Alterar(Aula aula)
        {
            contexto.Aula.Update(aula);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            var aula = Selecionar(id);
            contexto.Aula.Remove(aula);
            contexto.SaveChanges();
        }
    }
}
