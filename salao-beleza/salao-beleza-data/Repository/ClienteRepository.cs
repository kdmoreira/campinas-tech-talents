using Microsoft.EntityFrameworkCore;
using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Cliente> SelecionarTudoCompleto()
        {
            return _contexto.Cliente
                .Include(x => x.Agendamentos)
                .ToList();
        }
    }
}
