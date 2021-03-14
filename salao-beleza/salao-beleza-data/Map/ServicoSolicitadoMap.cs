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

            builder.HasKey(x => new { x.FuncionarioId, x.ServicoId });

            builder.HasOne<Funcionario>(fs => fs.Funcionario).WithMany(f => f.ServicosSolicitados)
                .HasForeignKey(fs => fs.FuncionarioId);

            builder.HasOne<Servico>(fs => fs.Servico).WithMany(s => s.ServicosSolicitados)
                .HasForeignKey(fs => fs.ServicoId);
        }
    }
}
