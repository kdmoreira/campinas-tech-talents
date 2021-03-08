using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class ServicoRepository : BaseRepository<Servico>
    {
        /* public List<Servico> SelecionarTudoCompleto()
        {
            return _contexto.Servico
                .Include(x => x.ServicoSolicitado)
                .ToList();
        } */
    }
}
