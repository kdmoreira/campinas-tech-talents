using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public bool Ativo { get; set; }

        // Navigation property
        public List<Aula> Aulas { get; set; }
    }
}
