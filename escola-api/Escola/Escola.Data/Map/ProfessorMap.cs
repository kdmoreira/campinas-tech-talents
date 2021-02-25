using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Data.Map
{
    class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(150)")
                .IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(30)")
                .IsRequired();
            builder.Property(x => x.Banco).HasColumnType("varchar(10)");
            builder.Property(x => x.Agencia).HasColumnType("varchar(10)");
            builder.Property(x => x.Conta).HasColumnType("varchar(20)");
            builder.Property(x => x.Ativo).IsRequired();
        }
    }
}
