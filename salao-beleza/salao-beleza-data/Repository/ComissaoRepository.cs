using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class ComissaoRepository : BaseRepository<Comissao>, IComissaoRepository
    {
        public ComissaoRepository(Contexto contexto) : base(contexto)
        {
        }
    }
}
