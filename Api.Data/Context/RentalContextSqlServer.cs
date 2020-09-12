﻿using System.Reflection;
using Api.Data.Common.Interfaces;
using Api.Data.Configurations;
using Api.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public sealed class RentalContextSqlServer : DbContext, IDbEntities
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Copies> Copies { get; set; }
        public DbSet<Starring> Starring { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Employees> Employees { get; set; }

        public RentalContextSqlServer(DbContextOptions<RentalContextSqlServer> options) : base(options)
        {
            //С этим твоя база будет каждый раз очищаться
            //Скорее всего это для проверки работы но не забудь это исправить
            Database.EnsureCreated();
        }

        public RentalContextSqlServer()
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // // docker ms sql server connection string
        //     // optionsBuilder.UseSqlServer(
        //     //     "Server=192.168.43.85,5000;Database=ApiDatabase;User Id=sa;Password=yrnn9&kDt-");
        //
        //
        //     //optionsBuilder.UseSqlServer("Data Source=DESKTOP-P87PH2B;Initial Catalog=ApiDatabase;Integrated Security=true;");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Все то же что было но не нужно руками дописывать / прописывать каждую конфигурацию
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}