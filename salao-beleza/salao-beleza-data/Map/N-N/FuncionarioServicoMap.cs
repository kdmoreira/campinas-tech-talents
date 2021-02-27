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

            builder.HasOne(x => x.Funcionario).WithMany(x => x.FuncionarioServico)
                .HasForeignKey(x => x.IdFuncionario);

            builder.HasOne(x => x.Servico).WithMany(x => x.FuncionarioServico)
               .HasForeignKey(x => x.IdServico);

            builder.Property(x => x.Id).UseIdentityColumn();

        }
    }
}
