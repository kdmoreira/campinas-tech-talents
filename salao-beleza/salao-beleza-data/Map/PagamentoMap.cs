using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");

            builder.HasKey(x => x.Id);

            builder.HasOne<Agendamento>(p => p.AgendamentoRealizado).WithOne(a => a.Pagamento);

            builder.Property(x => x.ValorServico).HasColumnType("float")
                .IsRequired();

            builder.Property(x => x.Comissao).HasColumnType("float")
                .IsRequired();

            builder.HasOne(p => p.Caixa).WithMany(cx => cx.Pagamentos);
        }
    }
}
