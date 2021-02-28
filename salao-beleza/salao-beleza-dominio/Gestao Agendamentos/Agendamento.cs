using System;
using System.Collections.Generic;
using System.Linq;

namespace salao_beleza_dominio
{
public class Agendamento : IEntity
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public ServicoSolicitado ServicoSolicitado { get; set; }
        public DateTime DataAgendamento { get; set; }
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

        public void IncluirAgendamento(Cliente cliente, 
            ServicoSolicitado servicoParaAgendar,
            DateTime dataAgendamento, BaseAgendamentos agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda, servicoParaAgendar, dataAgendamento) == true)
            {
                Console.WriteLine("Esse horário não está livre.\n");
            }
            else
            {
                Cliente = cliente;
                ServicoSolicitado = servicoParaAgendar;
                DataAgendamento = dataAgendamento;
                Anotacao = anotacao;

                Console.WriteLine("Agendamento feito com sucesso.\n");
            }
        }

        public void AlterarAgendamento(Cliente cliente, ServicoSolicitado servicoParaAgendar,
            DateTime dataAgendamento, BaseAgendamentos agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda, servicoParaAgendar, dataAgendamento) == true)
            {
                Console.WriteLine("Esse horário não está livre.");
            }
            else
            {
                Cliente = cliente;
                ServicoSolicitado = servicoParaAgendar;
                DataAgendamento = dataAgendamento;
                Anotacao = anotacao;

                Console.WriteLine("Agendamento feito com sucesso.");
            }
        }

        public bool PermiteAgendar(BaseAgendamentos agenda, ServicoSolicitado servicoParaAgendar, DateTime dataAgendamento)
        {
            return agenda.Agendamentos.Any(ag => (servicoParaAgendar.Funcionario == ag.ServicoSolicitado.Funcionario)
            && (dataAgendamento >= ag.DataAgendamento && dataAgendamento <= ag.DataAgendamento.AddMinutes(servicoParaAgendar.Servico.MinutosParaExecucao)) 
            && ag != this && (ag.Status != StatusAgenda.CanceladoPeloSalao || ag.Status != StatusAgenda.CanceladoPeloCliente));
        }

        public void IncluirServicoSolicitado(int id, Servico servico, Funcionario func)
        {
            ServicoSolicitado ss = new ServicoSolicitado();
            ss.Incluir(id, servico, func);
        }

        public void EditarStatus(StatusAgenda status, DateTime novaData, BaseAgendamentos agenda)
        {
            Status = status;
            this.AlterarAgendamento(this.Cliente, this.ServicoSolicitado, novaData, agenda);
        }

        public override string ToString()
        {
            return DataAgendamento + ": " + Cliente.Nome + " / " + ServicoSolicitado +
                " / Status agenda: " + Status;
        }

    }
}