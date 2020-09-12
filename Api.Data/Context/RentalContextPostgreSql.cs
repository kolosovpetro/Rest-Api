using System.Reflection;
using Api.Data.Common.Interfaces;
using Api.Data.Configurations;
using Api.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public sealed class RentalContextPostgreSql : DbContext, IDbEntities
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Copies> Copies { get; set; }
        public DbSet<Starring> Starring { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Employees> Employees { get; set; }

        public RentalContextPostgreSql(DbContextOptions<RentalContextPostgreSql> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public RentalContextPostgreSql()
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql(
        //         "Server=localhost;User Id=postgres;Password=postgres;Database=RentalCodeFirst;");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Все то же что было но не нужно руками дописывать / прописывать каждую конфигурацию
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}