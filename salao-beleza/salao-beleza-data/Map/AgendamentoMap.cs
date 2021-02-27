using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamento");

            builder.HasKey(x => x.Id);

            // incluir cliente

            // incluir servico solicitado

            // incluir data agendamento

            builder.Property(x => x.Anotacao).HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Status).HasColumnType("varchar(20)")
                .IsRequired(); // Qual column type para enum?

        }
    }
}
