using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using salao_beleza_dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace salao_beleza_data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Telefone).HasColumnType("varchar(15)")
               .IsRequired();

            builder.Property(x => x.Cpf).HasColumnType("varchar(11)")
               .IsRequired();

            builder.HasOne<Endereco>(c => c.Endereco).WithMany(e => e.Clientes);
        }
    }
}
