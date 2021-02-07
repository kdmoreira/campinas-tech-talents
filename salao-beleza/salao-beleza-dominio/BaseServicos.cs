using System.Collections.Generic;
using System.Linq;

namespace salao_beleza_dominio
{
    public class BaseServicos
    {
        public List<Servico> Servicos { get; set; }

        public BaseServicos()
        {
            Servicos = new List<Servico>();
        }

        // Inclusão individual de serviços
        public void Incluir(Servico serv)
        {
            int id = 0;
            if (this.Servicos.Any())
                id = Servicos.Last().Id + 1;
            else
                id++;
            serv.Id = id;
            Servicos.Add(serv);
        }

        // Inclusão de vários serviços
        public void Incluir(params Servico[] servicos)
        {
            foreach (Servico servico in servicos)
            {
                this.Incluir(servico);
            }
        }

        public void AlterarServico(int id, string nomeNovo, int minutosParaExecucaoNovo, float precoNovo)
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