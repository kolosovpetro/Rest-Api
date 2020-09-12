using Api.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Common.Interfaces
{
    //Не самое лучшее название но думаю суть понятна
    public interface IDbEntities
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Copies> Copies { get; set; }
        public DbSet<Starring> Starring { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}