using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Models.Models;
using Api.Repositories.Interfaces;
using AutoMapper;

namespace Api.Services.Services
{
    public class MoviesService
    {
        private readonly IRepository<Movies> _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesService(IRepository<Movies> moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MoviesReadDto>> GetAllMoviesAsync()
        {
            var movies = await _moviesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MoviesReadDto>>(movies);
        }
        
        public async Task<MoviesReadDto> GetByIdAsync(int id)
        {
            var model = await _moviesRepository.GetByIdAsync(id);
            return _mapper.Map<MoviesReadDto>(model);
        }

        private void DatabaseSaveChanges()
        {
            _moviesRepository.SaveChanges();
        }

        public async Task AddAndSaveAsync(MoviesCreateDto model)
        {
            var movie = _mapper.Map<Movies>(model);
            _moviesRepository.Add(movie);
            await _moviesRepository.SaveChangesAsync();
        }

        private async Task Update(int id, MovieUpdateDto dto)
        {
            var movie = await _moviesRepository.GetByIdAsync(id);
            //Хорошим решением будет сделать свои ексепшины и их возвращать
            //Но это уже как-то сам
            if (movie == null)
            {
                throw new ArgumentException($"Movie with id : {id} not found");
            }

            _mapper.Map(dto, movie);
            _moviesRepository.Update(movie);
        }

        public async Task UpdateAndSaveAsync(int id, MovieUpdateDto dto)
        {
            await Update(id, dto);
            DatabaseSaveChanges();
        }

        private async Task Delete(int id)
        {
            var movie = await _moviesRepository.GetByIdAsync(id);
            //Хорошим решением будет сделать свои ексепшины и их возвращать
            //Но это уже как-то сам
            if (movie == null)
            {
                throw new ArgumentException($"Movie with id : {id} not found");
            }
            _moviesRepository.Delete(movie);
        }

        public async Task DeleteAndSaveAsync(int id)
        {
            await Delete(id);
            DatabaseSaveChanges();
        }
    }
}