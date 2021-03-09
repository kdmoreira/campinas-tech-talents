using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class ComissaoMap : IEntityTypeConfiguration<Comissao>
    {
        public void Configure(EntityTypeBuilder<Comissao> builder)
        {
            builder.ToTable("Comissao");

            builder.HasKey(x => x.Id);

            builder.HasOne<Funcionario>(c => c.Funcionario).WithMany(f => f.ComissoesRecebidas);

            builder.Property(x => x.Valor).HasColumnType("float").IsRequired();

            builder.HasOne<BalancoMensal>(c => c.BalancoMensal).WithMany(f => f.ComissoesPagas);
        }
    }
}
