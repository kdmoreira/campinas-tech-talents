using System;
using System.Linq;
using System.Collections.Generic;

namespace salao_beleza_dominio
{
    public class Funcionario : IEntity
    {
        //public Funcionario()
        //{
        //    Servicos = new List<Servico>();
        //}

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public CargoFunc Cargo { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioSaida { get; set; }
        public enum CargoFunc
        {
            Cabeleireiro,
            Manicure,
            Esteticista,
            Barbeiro
        }
        // public List<Servico> Servicos { get; set; }
        public float ComissaoAReceber { get; set; }
        public List<Comissao> ComissoesRecebidas { get; set; }
        public List<FuncionarioServico> FuncionarioServico { get; set; }
        public List<ServicoSolicitado> ServicosSolicitados { get; set; }

        /* public void Incluir(string nome, string telefone, Endereco endereco, CargoFunc cargo)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Cargo = cargo;
        }

        public void Alterar(string nome, string telefone, Endereco endereco, CargoFunc cargo)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Cargo = cargo;
        }

        public void IncluirServico(Servico serv)
        {
            Servicos.Add(serv);
        }

        public void ExcluirServico(int id)
        {
            List<Servico> remover = Servicos.FindAll(f => f.Id == id);
            foreach (var remove in remover)
            {
                Servicos.Remove(remove);
            }
        }

        public override string ToString()
        {
            return Id + ": " + Nome + ", Tel: " + Telefone + ", Cargo: " +
                Cargo + ", " + HorarioEntrada.Hour.ToString("D2") + ":" +
                HorarioEntrada.Minute.ToString("D2") + " às " + HorarioSaida.Hour.ToString("D2") +
                ":" + HorarioSaida.Minute.ToString("D2") + ", a receber: " + ComissaoAReceber;
        } */
    }
}