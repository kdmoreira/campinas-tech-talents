using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Map
{
    public class AulaMap : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("Aula");

            builder.HasKey(x => x.Id);
          
            builder.Property(x => x.Assunto)
                .HasColumnType("varchar(50)").IsRequired();

            // 03/03
            builder.HasOne<Professor>(a => a.Professor).WithMany(p => p.Aulas);
            builder.HasOne<Turma>(a => a.Turma).WithMany(t => t.Aulas);
        }
    }
}
