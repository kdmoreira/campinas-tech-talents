using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain
{
    public class Aula
    {
        public int Id { get; set; }
        public int ProfessorID { get; set; }
        public string Disciplina { get; set; }
        public int TurmaID { get; set; }

        // Navigation Property
        public Professor Professor { get; set; }
        public Turma Turma { get; set; }
    }
}
