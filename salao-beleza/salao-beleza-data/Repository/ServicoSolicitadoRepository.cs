using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class ServicoSolicitadoRepository : BaseRepository<ServicoSolicitado>, IServicoSolicitadoRepository
    {
        public ServicoSolicitadoRepository(Contexto contexto) : base(contexto)
        {
        }
    }

}
