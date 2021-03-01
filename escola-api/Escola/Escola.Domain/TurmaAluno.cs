using System;

namespace Escola.Domain
{
    public class TurmaAluno : IEntity
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }
    }
}
