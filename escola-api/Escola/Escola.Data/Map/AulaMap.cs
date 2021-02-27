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
          
            builder.Property(x => x.Disciplina)
                .HasColumnType("varchar(30)").IsRequired();

        }
    }
}
