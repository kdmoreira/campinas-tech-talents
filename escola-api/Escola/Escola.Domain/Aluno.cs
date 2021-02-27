using System;
using System.Collections.Generic;

namespace Escola.Domain
{
    public class Aluno : ICalculoNota
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        
        public List<TurmaAluno> TurmaAluno { get; set; }

        public decimal Calcular(decimal n1, decimal n2, decimal n3)
        {
            return (n1 + n2 + n3) / 3;
        }
    }
}
