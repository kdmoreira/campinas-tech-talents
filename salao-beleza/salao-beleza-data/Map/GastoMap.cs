using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class GastoMap : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.ToTable("Gasto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Valor).HasColumnType("float")
                .IsRequired();

            builder.Property(x => x.Motivo).HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne<BalancoMensal>(g => g.BalancoMensal).WithMany(bm => bm.Gastos);
        }
    }
}
