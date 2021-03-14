using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Interface
{
    public interface ICaixaRepository : IBaseRepository<Caixa>
    {
        List<Caixa> SelecionarTudoCompleto();
    }
}
