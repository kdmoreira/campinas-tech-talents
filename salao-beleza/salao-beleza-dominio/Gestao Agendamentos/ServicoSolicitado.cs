using System;

namespace salao_beleza_dominio
{
public class ServicoSolicitado
    {
        public int Id { get; set; }
        public Servico Servico { get; set; }
        public Funcionario Funcionario { get; set; }
        public StatusServico Status { get; set; }
        public DateTime DataServico { get; set; }

        public enum StatusServico
        {
            ARealizar,
            Realizado,
            Reagendado,
            CanceladoPeloCliente,
            CanceladoPeloSalao
        }

        public void Incluir(int id, Servico servico, Funcionario func, DateTime data)
        {
            Id = id;
            Servico = servico;
            Funcionario = func;
            DataServico = data;
        }

        public void EditarStatus(StatusServico status)
        {
            Status = status;
        }

        public override string ToString()
        {
            return "Serviço Solicitado: " + Servico + ", com " + Funcionario.Nome + ", dia " + DataServico + " / Status serviço: " + Status;
        }
    }
}