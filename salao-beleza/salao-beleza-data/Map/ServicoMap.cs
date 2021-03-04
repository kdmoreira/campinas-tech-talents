using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servico");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(x => x.MinutosParaExecucao).HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Preco).HasColumnType("float").IsRequired();

            builder.HasMany<ServicoSolicitado>(s => s.ServicosSolicitados).WithOne(s => s.Servico);
        }
    }
}
