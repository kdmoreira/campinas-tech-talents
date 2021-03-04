using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Map
{
    public class TurmaProfessorMap : IEntityTypeConfiguration<TurmaProfessor>
    {
        public void Configure(EntityTypeBuilder<TurmaProfessor> builder)
        {
            builder.ToTable("TurmaProfessor");

            builder.HasKey(tp => new { tp.IdProfessor, tp.IdTurma });

            builder.HasOne<Professor>(tp => tp.Professor).WithMany(p => p.TurmaProfessor)
                .HasForeignKey(tp => tp.IdProfessor);

            builder.HasOne<Turma>(tp => tp.Turma).WithMany(t => t.TurmaProfessor)
                .HasForeignKey(tp => tp.IdTurma);
        }
    }
}
