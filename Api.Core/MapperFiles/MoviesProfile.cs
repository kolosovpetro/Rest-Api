using Api.Models.DTO;
using Api.Models.Models;
using AutoMapper;

namespace Api.MapperFiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            // source -> target
            CreateMap<Movies, MoviesReadDto>();
            CreateMap<MoviesCreateDto, Movies>();
            CreateMap<MovieUpdateDto, Movies>().ReverseMap();
                
        }
    }
}