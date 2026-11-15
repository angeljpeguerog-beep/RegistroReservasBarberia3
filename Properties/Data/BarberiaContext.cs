

using Microsoft.EntityFrameworkCore;
using SistemaBarberiaPOO.Models;

namespace SistemaBarberiaPOO.Data
{
    public class BarberiaContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=.\SQLEXPRESS;
                      Database=BarberiaDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
        }
    }
}

