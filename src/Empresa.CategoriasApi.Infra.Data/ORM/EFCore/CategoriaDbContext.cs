﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Empresa.CategoriasApi.Infra.Data.ORM.EFCore
{
    public class CategoriaDbContext : DbContext
    {
        public CategoriaDbContext(DbContextOptions options)
            : base(options) =>
                this.Database.EnsureCreated();
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Mostra o script SQL no console
            optionsBuilder.UseLoggerFactory(loggerFactory: LoggerFactory.Create(x =>
                x.AddConsole()
            ));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Busca por todas as Classes que implementam IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoriaDbContext).Assembly);
        }
    }
}
