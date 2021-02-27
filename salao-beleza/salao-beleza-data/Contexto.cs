﻿using Microsoft.EntityFrameworkCore;
using salao_beleza_dominio;
using System;

namespace salao_beleza_data
{
    public class Contexto : DbContext
    {
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ServicoSolicitado> ServicoSolicitado { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JETDHQT\\SQLEXPRESS; DataBase=SalaoBeleza; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ServicoSolicitadoMap());
            modelBuilder.ApplyConfiguration(new AgendamentoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}