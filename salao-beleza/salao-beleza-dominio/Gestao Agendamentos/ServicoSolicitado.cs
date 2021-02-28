using System;

namespace salao_beleza_dominio
{
public class ServicoSolicitado : IEntity
    {
        public int Id { get; set; }
        public Servico Servico { get; set; }
        public Funcionario Funcionario { get; set; }

        public void Incluir(int id, Servico servico, Funcionario func)
        {
            Id = id;
            Servico = servico;
            Funcionario = func;
        }

        public override string ToString()
        {
            return "Serviço Solicitado: " + Servico + ", com " +
                Funcionario.Nome;
        }
    }
}