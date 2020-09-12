using System;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Services.Services;
using Microsoft.AspNetCore.JsonPatch;
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
            catch (Exception e)
            {
                return NotFound();
            }

            return NoContent();
        }

        // PATCH api/movies/{id}
        //Не очень понял для чего этот метод поэтому не менял ничего
        //Думаю сам справишься на основе примеров выше
        // [HttpPatch("{id}")]
        // public async Task<IActionResult> PartialMovieUpdate(int id, JsonPatchDocument<MovieUpdateDto> patchDocument)
        // {
        //     var movieModel = await _moviesService.GetByIdAsync(id);
        //     if (movieModel == null)
        //         return NotFound();
        //
        //     var movieToPatch = _moviesService.ModelMapToUpdateDto(movieModel);
        //     patchDocument.ApplyTo(movieToPatch, ModelState);
        //
        //     if (!TryValidateModel(movieToPatch))
        //         return ValidationProblem(ModelState);
        //
        //     _moviesService.UpdateDtoMapToModel(movieToPatch, movieModel);
        //     _moviesService.DatabaseUpdate(movieModel);
        //     _moviesService.DatabaseSaveChanges();
        //     return NoContent();
        // }

        // DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _moviesService.DeleteAndSaveAsync(id);
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}