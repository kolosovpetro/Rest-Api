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
        private readonly MoviesServices _moviesServices;

        public MoviesController(MoviesServices moviesServices)
        {
            _moviesServices = moviesServices;
        }

        // GET api/movies
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var moviesEnumerable = await _moviesServices.GetAllMoviesAsync();
            var mappedEnumerable = _moviesServices.MoviesEnumMapToDto(moviesEnumerable);
            return Ok(mappedEnumerable);
        }

        // GET api/movies/{id}
        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var model = await _moviesServices.GetModelByIdAsync(id);

            if (model == null)
                return NotFound();

            var mapped = _moviesServices.ModelMapToReadDto(model);
            return Ok(mapped);
        }

        // POST api/movies
        [HttpPost]
        public IActionResult CreateMovies(MoviesCreateDto moviesCreateDto)
        {
            var model = _moviesServices.CreateDtoMapToModel(moviesCreateDto);
            _moviesServices.DatabaseAdd(model);
            _moviesServices.DatabaseSaveChanges();
            var moviesReadDto = _moviesServices.ModelMapToReadDto(model);
            return CreatedAtRoute(nameof(GetMovieById), new {Id = model.MovieId}, moviesReadDto);
        }

        // PUT api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDto movieUpdateDto)
        {
            var movieModel = await _moviesServices.GetModelByIdAsync(id);

            if (movieModel == null)
                return NotFound();

            _moviesServices.UpdateDtoMapToModel(movieUpdateDto, movieModel);
            _moviesServices.DatabaseUpdate(movieModel);
            _moviesServices.DatabaseSaveChanges();
            return NoContent();
        }

        // PATCH api/movies/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialMovieUpdate(int id, JsonPatchDocument<MovieUpdateDto> patchDocument)
        {
            var movieModel = await _moviesServices.GetModelByIdAsync(id);
            if (movieModel == null)
                return NotFound();

            var movieToPatch = _moviesServices.ModelMapToUpdateDto(movieModel);
            patchDocument.ApplyTo(movieToPatch, ModelState);

            if (!TryValidateModel(movieToPatch))
                return ValidationProblem(ModelState);

            _moviesServices.UpdateDtoMapToModel(movieToPatch, movieModel);
            _moviesServices.DatabaseUpdate(movieModel);
            _moviesServices.DatabaseSaveChanges();
            return NoContent();
        }

        // DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var model = await _moviesServices.GetModelByIdAsync(id);

            if (model == null)
                return NotFound();

            _moviesServices.DatabaseDelete(model);
            _moviesServices.DatabaseSaveChanges();
            return NoContent();
        }
    }
}