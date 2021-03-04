using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Curso).
                HasColumnType("varchar(60)").IsRequired();

            builder.Property(x => x.Edicao).
                HasColumnType("int").IsRequired();

            builder.HasMany<Aula>(x => x.Aulas).WithOne(x => x.Turma);
        }
    }
}
