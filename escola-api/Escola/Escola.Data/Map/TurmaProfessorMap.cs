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

            builder.HasKey(x => new { x.IdProfessor, x.IdTurma });

            builder.HasOne(t => t.Turma).WithMany(tp => tp.TurmaProfessor)
                .HasForeignKey(x => x.IdTurma);

            builder.HasOne(p => p.Professor).WithMany(tp => tp.TurmaProfessor)
               .HasForeignKey(x => x.IdProfessor);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
