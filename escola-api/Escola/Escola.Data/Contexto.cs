using Escola.Data.Map;
using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Escola.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Aula> Aula { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<TurmaProfessor> TurmaProfessor { get; set; }
        public DbSet<TurmaAluno> TurmaAluno { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JETDHQT\\SQLEXPRESS; DataBase=Escola; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new AulaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaAlunoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
