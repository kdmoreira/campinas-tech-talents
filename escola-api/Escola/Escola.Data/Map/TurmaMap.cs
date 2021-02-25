using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AnoEscolar).
                HasColumnType("int").IsRequired();
            builder.Property(x => x.Sala).HasColumnType("varchar(10)").IsRequired();
        }
    }
}
