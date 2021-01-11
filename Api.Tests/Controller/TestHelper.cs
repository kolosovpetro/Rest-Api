using System.Collections.Generic;
using System.Threading.Tasks;
using Api.MapperFiles;
using Api.Models.DTO;
using Api.Models.Models;
using AutoMapper;

namespace Api.Tests.Controller
{
    public static class TestHelper
    {
        public static Task<IEnumerable<MoviesReadDto>> MappedMovies(IEnumerable<Movies> collection, IMapperBase mapper)
        {
            return Task.FromResult(mapper.Map<IEnumerable<MoviesReadDto>>(collection));
        }

        public static readonly IEnumerable<Movies> AllMovies = new List<Movies>
        {
            new Movies(1, "Star Wars Episode IV: A New Hope", 1979, 12, 10f),
            new Movies(2, "Ghostbusters", 1984, 12, 5.5f),
            new Movies(3, "Terminator", 1984, 15, 8.5f),
            new Movies(4, "Taxi Driver", 1976, 17, 5f),
            new Movies(5, "Platoon", 1986, 18, 5f),
            new Movies(6, "Frantic", 1988, 15, 8.5f),
            new Movies(7, "Ronin", 1998, 13, 9.5f),
            new Movies(8, "Analyze This", 1999, 16, 10.5f),
            new Movies(9, "Leon: the Professional", 1994, 16, 8.5f),
            new Movies(10, "Mission Impossible", 1996, 13, 8.5f)
        };

        private static readonly MoviesProfile Profile = new MoviesProfile();

        private static readonly MapperConfiguration Configuration = 
            new MapperConfiguration(cfg => cfg.AddProfile(Profile));

        public static readonly Mapper Mapper = new Mapper(Configuration);
    }
}