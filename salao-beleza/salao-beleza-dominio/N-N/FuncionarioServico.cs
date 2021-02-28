using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_dominio
{
    public class FuncionarioServico : IEntity
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }
        public int IdServico { get; set; }
        public Servico Servico { get; set; }
    }
}
