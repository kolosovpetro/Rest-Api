using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Models.Models;
using Api.Repositories.Interfaces;
using AutoMapper;

namespace Api.Services.Services
{
    public class MoviesServices
    {
        private readonly IRepository<Movies> _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesServices(IRepository<Movies> moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public IEnumerable<MoviesReadDto> MoviesEnumMapToDto(IEnumerable<Movies> moviesEnumerable)
        {
            var mappedEnumerable = _mapper.Map<IEnumerable<MoviesReadDto>>(moviesEnumerable.OrderBy(x => x.MovieId));
            return mappedEnumerable;
        }

        public async Task<IEnumerable<Movies>> GetAllMoviesAsync()
        {
            var movies = await _moviesRepository.GetAllAsync();
            return movies;
        }

        public MoviesReadDto ModelMapToReadDto(Movies model)
        {
            var mapped = _mapper.Map<MoviesReadDto>(model);
            return mapped;
        }

        public async Task<Movies> GetModelByIdAsync(int id)
        {
            var model = await _moviesRepository.GetByIdAsync(id);
            return model;
        }

        public void DatabaseSaveChanges()
        {
            _moviesRepository.SaveChanges();
        }

        public void DatabaseAdd(Movies model)
        {
            _moviesRepository.Add(model);
        }

        public Movies CreateDtoMapToModel(MoviesCreateDto moviesCreateDto)
        {
            var model = _mapper.Map<Movies>(moviesCreateDto);
            return model;
        }

        public void DatabaseUpdate(Movies movieModel)
        {
            _moviesRepository.Update(movieModel);
        }

        public void UpdateDtoMapToModel(MovieUpdateDto movieToPatch, Movies movieModel)
        {
            _mapper.Map(movieToPatch, movieModel);
        }

        public MovieUpdateDto ModelMapToUpdateDto(Movies movieModel)
        {
            var movieToPatch = _mapper.Map<MovieUpdateDto>(movieModel);
            return movieToPatch;
        }

        public void DatabaseDelete(Movies model)
        {
            _moviesRepository.Delete(model);
        }
    }
}