﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(x => x.Data).HasColumnType("datetime");

            builder.Property(x => x.TotalDiario).HasColumnType("float");

            builder.Property(x => x.ComissaoDiaria).HasColumnType("varchar(15)");

            builder.Property(x => x.LucroDiario).HasColumnType("varchar(15)");

            builder.HasMany<Pagamento>(cx => cx.Pagamentos).WithOne(p => p.Caixa);

            builder.HasOne<BalancoMensal>(cx => cx.BalancoMensal).WithMany(bm => bm.Caixas);
        }
    }
}
