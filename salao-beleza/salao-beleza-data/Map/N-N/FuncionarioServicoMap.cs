using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map.N_N
{
    class FuncionarioServicoMap : IEntityTypeConfiguration<FuncionarioServico>
    {
        public void Configure(EntityTypeBuilder<FuncionarioServico> builder)
        {
            builder.ToTable("FuncionarioServico");

            builder.HasKey(x => x.Id);

            builder.HasKey(x => new { x.IdFuncionario, x.IdServico });

            builder.HasOne<Funcionario>(fs => fs.Funcionario).WithMany(f => f.FuncionarioServico)
                .HasForeignKey(fs => fs.IdFuncionario);

            builder.HasOne<Servico>(fs => fs.Servico).WithMany(s => s.FuncionarioServico)
                .HasForeignKey(fs => fs.IdServico);
        }
    }
}
