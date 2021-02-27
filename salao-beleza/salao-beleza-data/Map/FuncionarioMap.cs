using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Telefone).HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(x => x.Cargo).HasColumnType("varchar(11)")
                .IsRequired(); // Qual column type para enum?

            builder.Property(x => x.HorarioEntrada).HasColumnType("varchar(11)")
                .IsRequired(); // Qual column type para datetime?

            builder.Property(x => x.HorarioSaida).HasColumnType("varchar(11)")
                .IsRequired(); // Qual column type para datetime?

            builder.Property(x => x.ComissaoAReceber).HasColumnType("float");

        }
    }
}
