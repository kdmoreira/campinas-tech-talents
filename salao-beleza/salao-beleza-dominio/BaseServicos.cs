using System.Collections.Generic;
using System.Linq;

namespace salao_beleza_dominio
{
    public class MinhaBaseServicos
    {
        public List<Servico> Servicos { get; set; }

        public MinhaBaseServicos()
        {
            Servicos = new List<Servico>();
        }

        public void Incluir(Servico serv)
        {
            Servicos.Add(serv);
        }

        public void AlterarUmServico(int id, string nomeNovo, int minutosParaExecucaoNovo, float precoNovo)
        {
            Servico servico = Servicos.FirstOrDefault();
            if (servico != null)
            {
                servico.Alterar(nomeNovo, minutosParaExecucaoNovo,
                precoNovo);
            }
        }

        public void ExcluirUmServico(int id)
        {
            Servicos.RemoveAll(serv => serv.Id == id);
        }
    }
}