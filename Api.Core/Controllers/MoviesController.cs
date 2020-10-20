using System;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        private readonly MoviesService _moviesService;

        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        // GET api/movies
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _moviesService.GetAllMoviesAsync());
        }

        // GET api/movies/{id}
        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var model = await _moviesService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        // POST api/movies
        [HttpPost]
        public async Task<IActionResult> CreateMovies(MoviesCreateDto moviesCreateDto)
        {
            await _moviesService.AddAndSaveAsync(moviesCreateDto);

            return NoContent();
        }

        // PUT api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDto movieUpdateDto)
        {
            try
            {
                await _moviesService.UpdateAndSaveAsync(id, movieUpdateDto);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _moviesService.DeleteAndSaveAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}