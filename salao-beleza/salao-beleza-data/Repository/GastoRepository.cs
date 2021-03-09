using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class GastoRepository : BaseRepository<Gasto>, IGastoRepository
    {
        public GastoRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
