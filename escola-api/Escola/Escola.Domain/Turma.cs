using System;
using System.Collections.Generic;

namespace Escola.Domain
{
    public class Turma : IEntity
    {
        public int Id { get; set; }
        public string Curso { get; set; }
        public int Edicao { get; set; }

        public List<TurmaProfessor> TurmaProfessor { get; set; }
        public List<TurmaAluno> TurmaAluno { get; set; }
        public List<Aula> Aulas { get; set; }
    }
}
