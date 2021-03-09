using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Logradouro).HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(x => x.CEP).HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(x => x.Bairro).HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(x => x.Cidade).HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(x => x.UF).HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(x => x.Numero).HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(x => x.Complemento).HasColumnType("varchar(10)");

            builder.HasMany<Cliente>(e => e.Clientes).WithOne(c => c.Endereco);

            builder.HasMany<Funcionario>(e => e.Funcionarios).WithOne(f => f.Endereco);
        }
    }
}
