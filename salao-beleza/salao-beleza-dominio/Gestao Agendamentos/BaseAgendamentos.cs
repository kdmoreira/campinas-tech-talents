using System;
using System.Collections.Generic;
using System.Linq;

namespace salao_beleza_dominio
{
    public class BaseAgendamentos
    {
        public List<Agendamento> Agendamentos { get; set; }

        public BaseAgendamentos()
        {
            Agendamentos = new List<Agendamento>();
        }

        public void Agendar(Agendamento agendamento)
        {
            Agendamentos.Add(agendamento);
        }

        public void Visualizar()
        {
            Console.WriteLine("Agendamentos:");
            foreach (Agendamento agendamento in Agendamentos)
            {
                Console.WriteLine(agendamento);
            }
            Console.WriteLine();
        }

        public void VisualizarData(DateTime data)
        {
            Console.WriteLine("Agendamentos na data informada:");
            List<Agendamento> agendamentosWhere =
            Agendamentos.Where(x => x.DataChegada.Equals(data.Date)).ToList();
            if (agendamentosWhere.Count == 0)
            {
                Console.WriteLine("Não há agendamentos nesta data.");
            }
            else
            {
                foreach (Agendamento agendamento in agendamentosWhere)
                {
                    Console.WriteLine(agendamento);
                }
                Console.WriteLine();
            }
        }
    }
}