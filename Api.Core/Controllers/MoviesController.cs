using System;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Returns list of all the movies in database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Returns list of all the movies in database.")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _moviesService.GetAllMoviesAsync());
        }

        /// <summary>
        /// Returns movie by Id.
        /// </summary>
        [HttpGet("{id}", Name = "GetMovieById")]
        [SwaggerOperation(Summary = "Returns movie by Id.")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var model = await _moviesService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        /// <summary>
        /// Adds new movie to database.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds new movie to database.")]
        [HttpPost]
        public async Task<IActionResult> CreateMovies(MoviesCreateDto moviesCreateDto)
        {
            await _moviesService.AddAndSaveAsync(moviesCreateDto);

            return NoContent();
        }

        /// <summary>
        /// Modifies an existing movie in database.
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Modifies an existing movie in database.")]
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

        /// <summary>
        /// Deletes movie from database by Id. Returns response.
        /// </summary>
        [HttpDelete]
        [SwaggerOperation(Summary = "Deletes movie from database by Id.")]
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