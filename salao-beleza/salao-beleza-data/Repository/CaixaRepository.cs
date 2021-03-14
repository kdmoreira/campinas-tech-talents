using Microsoft.EntityFrameworkCore;
using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class CaixaRepository : BaseRepository<Caixa>, ICaixaRepository
    {
        public CaixaRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Caixa> SelecionarTudoCompleto()
        {
            return _contexto.Caixa
                .Include(x => x.Pagamentos)
                .ToList();
        }
    }
}
