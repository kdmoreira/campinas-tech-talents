using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class BalancoMensalMap : IEntityTypeConfiguration<BalancoMensal>
    {
        public void Configure(EntityTypeBuilder<BalancoMensal> builder)
        {
            builder.ToTable("BalancoMensal");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Mes).HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Ano).HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.TotalMensal).HasColumnType("float")
                .IsRequired();

            builder.Property(x => x.ComissaoMensal).HasColumnType("float")
                .IsRequired();

            builder.Property(x => x.LucroMensal).HasColumnType("float")
                .IsRequired();

            // lista gastos

            // lista caixa

            // dicionário comissões pagas
        }
    }
}
