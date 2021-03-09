using System;
using System.Collections.Generic;
using System.Linq;

namespace salao_beleza_dominio
{
    public class BaseAgendamentos
    {
        /* public List<Agendamento> Agendamentos { get; set; }

        public BaseAgendamentos()
        {
            Agendamentos = new List<Agendamento>();
        }

        public void Agendar(Agendamento agendamento)
        {
            int id = 0;
            if (Agendamentos.Any())
                id = Agendamentos.Last().Id + 1;
            else
                id++;
            agendamento.Id = id;
            Agendamentos.Add(agendamento);
        }

        // Inclusão de vários agendamentos
        public void Agendar(params Agendamento[] agendamentos)
        {
            foreach (Agendamento agendamento in agendamentos)
            {
                this.Agendar(agendamento);
            }
        }

        public void Visualizar()
        {
            Console.WriteLine("TODOS OS AGENDAMENTOS:");
            foreach (Agendamento agendamento in Agendamentos)
            {
                Console.WriteLine(agendamento);
            }
            Console.WriteLine();
        }

        public void VisualizarData(DateTime data)
        {
            Console.WriteLine("AGENDAMENTOS NA DATA INFORMADA:");
            List<Agendamento> agendamentosWhere =
            Agendamentos.Where(x => x.DataAgendamento.Equals(data)).ToList();
            if (agendamentosWhere.Count == 0)
            {
                Console.WriteLine("Não há agendamentos nesta data.\n");
            }
            else
            {
                foreach (Agendamento agendamento in agendamentosWhere)
                {
                    Console.WriteLine(agendamento);
                }
                Console.WriteLine();
            }
        } */
    }
}