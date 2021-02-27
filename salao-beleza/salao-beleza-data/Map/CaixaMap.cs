using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class CaixaMap : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.ToTable("Caixa");

            builder.HasKey(x => x.Id);

            // incluir data

            builder.Property(x => x.TotalDiario).HasColumnType("float")
                .IsRequired();

            builder.Property(x => x.ComissaoDiaria).HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(x => x.LucroDiario).HasColumnType("varchar(15)")
                .IsRequired();

            // Lista pagamentos

        }
    }
}
