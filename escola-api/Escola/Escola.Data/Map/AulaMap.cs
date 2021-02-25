using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Data.Map
{
    public class AulaMap : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("Aula");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Professor).WithMany(x => x.Aulas)
                .HasForeignKey(x => x.ProfessorID);
            builder.Property(x => x.Disciplina).
                HasColumnType("varchar(30)").IsRequired();
            builder.HasOne(x => x.Turma).WithMany(x => x.Aulas)
                .HasForeignKey(x => x.TurmaID).IsRequired();
        }
    }
}
