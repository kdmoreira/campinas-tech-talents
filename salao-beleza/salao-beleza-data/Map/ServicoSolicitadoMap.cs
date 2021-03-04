using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class ServicoSolicitadoMap : IEntityTypeConfiguration<ServicoSolicitado>
    {
        public void Configure(EntityTypeBuilder<ServicoSolicitado> builder)
        {
            builder.ToTable("ServicoSolicitado");

            builder.HasKey(x => x.Id);

            // incluir servico
            builder.HasOne<Servico>(ss => ss.Servico).WithMany(s => s.ServicosSolicitados);

            // incluir funcionario
            builder.HasOne<Funcionario>(ss => ss.Funcionario).WithMany(f => f.ServicosSolicitados);

        }
    }
}
