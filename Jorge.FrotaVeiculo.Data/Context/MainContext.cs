using Jorge.FrotaVeiculo.Data.Mapping;
using Jorge.FrotaVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jorge.FrotaVeiculo.Data.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Veiculo> Veiculo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BaseMap<>)));
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder
       .UseSqlServer(@"Server=teste-frota.database.windows.net;Initial Catalog=teste-frota;Persist Security Info=False;User ID=testefrota;Password=Teste@123Frota;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
