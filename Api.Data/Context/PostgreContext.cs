using System.Reflection;
using Api.Data.Common.Interfaces;
using Api.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public sealed class PostgreContext : DbContext, IDbEntities
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Copies> Copies { get; set; }
        public DbSet<Starring> Starring { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Employees> Employees { get; set; }

        public PostgreContext()
        {
        }
        
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;User Id=postgres;Password=postgres;Database=ApiDatabase;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Все то же что было но не нужно руками дописывать / прописывать каждую конфигурацию
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}