using Api.Models.Models;
using Api.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Repositories
{
    public class MoviesRepository : RepositoryBase<Movies>
    {
        public MoviesRepository(DbContext rentalContext) : base(rentalContext)
        {
        }
    }
}