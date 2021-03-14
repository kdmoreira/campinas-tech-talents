using Microsoft.EntityFrameworkCore;
using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Servico> SelecionarTudoCompleto()
        {
            return _contexto.Servico
                .Include(x => x.ServicosSolicitados)
                .ToList();
        }
    }
}
