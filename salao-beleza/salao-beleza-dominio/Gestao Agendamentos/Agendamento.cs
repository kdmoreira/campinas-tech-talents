using System;
using System.Collections.Generic;
using System.Linq;

namespace salao_beleza_dominio
{
public class Agendamento
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public ServicoSolicitado ServicoSolicitado { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataChegada { get; set; }
        public string Anotacao { get; set; }
        public StatusAgenda Status { get; set; }

        public enum StatusAgenda
        {
            Realizado,
            Reagendado,
            CanceladoPeloCliente,
            NaoCompareceu,
            CanceladoPeloSalao,
            Pendente
        }

        public void IncluirAgendamento(int id, Cliente cliente, 
            ServicoSolicitado servicoParaAgendar,
            DateTime dataAgendamento, BaseAgendamentos agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda, servicoParaAgendar, dataAgendamento))
            {
                Console.WriteLine("Esse horário não está livre.");
            }
            else
            {
                Id = id;
                Cliente = cliente;
                ServicoSolicitado = servicoParaAgendar;
                DataAgendamento = dataAgendamento;
                Anotacao = anotacao;

                Console.WriteLine("Agendamento feito com sucesso.");
            }
        }

        public string AlterarAgendamento(Cliente cliente, ServicoSolicitado servicoParaAgendar,
            DateTime dataAgendamento, BaseAgendamentos agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda, servicoParaAgendar, dataAgendamento))
            {
                return "Esse horário não está livre.";
            }
            else
            {
                servicoParaAgendar.Status = ServicoSolicitado.StatusServico.Reagendado;
                Cliente = cliente;
                ServicoSolicitado = servicoParaAgendar;
                DataAgendamento = dataAgendamento;
                Anotacao = anotacao;

                return "Agendamento feito com sucesso.";
            }
        }

        /* Alterei: incluí agenda da classe BaseAgendamentos como 
        parâmetro, a consulta é feita na lista Agendamentos, contida na
        classe */
        private bool PermiteAgendar(BaseAgendamentos agenda, ServicoSolicitado servicoParaAgendar, DateTime dataAgendamento)
        {
            DateTime dataTerminoParaAgendar = dataAgendamento.AddMinutes(servicoParaAgendar.Servico.MinutosParaExecucao);
            return (agenda.Agendamentos.Any(a => a.DataAgendamento >= dataAgendamento &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)) &&
                agenda.Agendamentos.Any(a => a.DataAgendamento <= dataTerminoParaAgendar &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)));
        }

        public void IncluirServicoSolicitado(int id, Servico servico, Funcionario func, DateTime data)
        {
            ServicoSolicitado ss = new ServicoSolicitado();
            ss.Incluir(id, servico, func, data);
        }

        /* Incluí: editar status do agendamento */
        public void EditarStatus(StatusAgenda status, DateTime novaData)
        {
            Status = status;
        }

        public override string ToString()
        {
            return Id + ": " + Cliente.Nome + " / " + ServicoSolicitado + " / Status agenda: " + Status;
        }

    }
}