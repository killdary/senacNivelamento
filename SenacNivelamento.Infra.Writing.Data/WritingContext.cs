using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SenacNivelamento.Application.Common.Interfaces;
using SenacNivelamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SenacNivelamento.Infra.Writing.Data
{
    public class WritingContext : DbContext, IApplicationDbContext
    {

        private readonly string _writingConnectionString;
        public WritingContext()
        { }

        public WritingContext(DbContextOptions options) : base(options) { }

        public WritingContext(string writingConnectionString)
        {
            _writingConnectionString = writingConnectionString;
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!string.IsNullOrEmpty(_writingConnectionString))
                {
                    optionsBuilder.UseSqlite(_writingConnectionString);
                }
                else
                {
                    var configuration = new ConfigurationBuilder()
                       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                       .AddJsonFile("appsettings.develop.json")
                       .Build();

                    optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelbuilder.Entity<Funcionario>()
                .HasOne(f => f.Cargo)
                .WithMany(c => c.Funcionarios)
                .HasForeignKey(c => c.CargoId);

            modelbuilder.Entity<Funcionario>()
                .HasOne(f => f.Empresa)
                .WithMany(c => c.Funcionarios)
                .HasForeignKey(c => c.EmpresaId);

            modelbuilder.Entity<Cargo>()
                .Property(p => p.NivelAcesso)
                .HasConversion<short>();

            base.OnModelCreating(modelbuilder);
        }

    }
}
