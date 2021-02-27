using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Map
{
    public class TurmaAlunoMap : IEntityTypeConfiguration<TurmaAluno>
    {
        public void Configure(EntityTypeBuilder<TurmaAluno> builder)
        {
            builder.ToTable("TurmaAluno");

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasKey(x => new { x.IdAluno, x.IdTurma });

            builder.HasOne(t => t.Turma).WithMany(ta => ta.TurmaAluno)
                .HasForeignKey(x => x.IdTurma);

            builder.HasOne(a => a.Aluno).WithMany(ta => ta.TurmaAluno)
               .HasForeignKey(x => x.IdAluno);
        }
    }
}
