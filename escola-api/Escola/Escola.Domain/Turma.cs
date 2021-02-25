using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain
{
    public class Turma
    {
        public int Id { get; set; }
        public int AnoEscolar { get; set; }
        public string Sala { get; set; }

        // Navigation property
        public List<Aula> Aulas { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Professor> Professores { get; set; }
    }
}
