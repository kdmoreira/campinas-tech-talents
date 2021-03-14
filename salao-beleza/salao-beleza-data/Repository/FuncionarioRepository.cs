using Microsoft.EntityFrameworkCore;
using salao_beleza_data.Interface;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace salao_beleza_data.Repository
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Funcionario> SelecionarTudoCompleto()
        {
            return _contexto.Funcionario
                .Include(x => x.ComissoesRecebidas)
                .Include(x => x.ServicosSolicitados)
                .ToList();
        }

        /* public void ExcluirServico(int id)
        {
            List<Servico> remover = _contexto.FuncionarioServico.FindAll(f => f.Id == id);
            foreach (var remove in remover)
            {
                Servicos.Remove(remove);
            }
        }

        public void IncluirServico(Servico serv)
        {
            Servicos.Add(serv);
        } */
    }
}
