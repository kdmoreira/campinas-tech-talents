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

            builder.HasOne<Cliente>(a => a.Cliente).WithMany(c => c.Agendamentos);

            builder.HasOne<ServicoSolicitado>(a => a.ServicoSolicitado)
                .WithMany(ss => ss.Agendamentos);

            builder.Property(a => a.DataAgendamento).HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Anotacao).HasColumnType("varchar(100)");

            builder.Property(x => x.Status).HasColumnType("int")
                .IsRequired();

            builder.HasOne<Pagamento>(a => a.Pagamento)
                .WithOne(p => p.AgendamentoRealizado);
        }
    }
}
