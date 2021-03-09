using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_dominio
{
    public class Comissao : IEntity
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public float Valor { get; set; }
        public BalancoMensal BalancoMensal { get; set; }
    }
}
