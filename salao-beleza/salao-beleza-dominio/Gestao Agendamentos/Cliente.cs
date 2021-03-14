using System.Collections.Generic;

namespace salao_beleza_dominio
{
    public class Cliente : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public List<Agendamento> Agendamentos { get; set; }

        /* public void Incluir(string nome, string telefone, string cpf, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            Endereco = endereco;
        }

        public void Alterar(string nome, string telefone, Endereco endereco)
        {
            Nome = string.IsNullOrEmpty(nome) ? Nome : nome;
            Telefone = string.IsNullOrEmpty(telefone) ? Telefone : telefone;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return Id + ": " + Nome + ", Tel: " + Telefone + ", CPF: " + Cpf;
        } */
    }
}
