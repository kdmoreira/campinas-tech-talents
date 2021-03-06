using Escola.Data.Interface;
using Escola.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Contexto contexto) : base(contexto)
        {

        }

        public Usuario SelecionarPorNomeESenha(string nome, string senha)
        {
            return _contexto.Set<Usuario>().FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
        }
    }
}
