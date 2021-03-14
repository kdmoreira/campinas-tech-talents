using Microsoft.EntityFrameworkCore;
using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class BalancoMensalRepository : BaseRepository<BalancoMensal>, IBalancoMensalRepository
    {
        public BalancoMensalRepository(Contexto contexto) : base(contexto)
        {

        }

        public List<BalancoMensal> SelecionarTudoCompleto()
        {
            return _contexto.BalancoMensal
                .Include(x => x.Gastos)
                .Include(x => x.Caixas)
                .Include(x => x.ComissoesPagas)
                .ToList();
        }
    }
}
