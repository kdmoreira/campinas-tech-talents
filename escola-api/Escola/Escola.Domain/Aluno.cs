using System;

namespace Escola.Domain
{
    public class Aluno : ICalculoNota
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int TurmaID { get; set; }

        // Navigation property
        public Turma Turma { get; set; }

        public decimal Calcular(decimal n1, decimal n2, decimal n3)
        {
            return (n1 + n2 + n3) / 3;
        }
    }
}
