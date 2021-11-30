using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimatedSeriesAPI.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public ActionResult<GenreDto> GetAll()
        {
            var genre = _genreRepository.GetAll() ;

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<GenreDto> Get([FromRoute] int id)
        {
            var genre = _genreRepository.GetSingle(id);

            return Ok(genre);
        }

        [HttpPost]
        public ActionResult CreatePlaylist([FromBody] CreateGenreDto dto)
        {
            var id = _genreRepository.Add(dto);

            return Created($"/genre/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult<GenreDto> Delete([FromRoute] int id)
        {
            _genreRepository.Delete(id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<GenreDto> Update([FromRoute] int id, [FromBody] UpdateGenreDto dto)
        {
            _genreRepository.Update(dto, id);

            return Ok();
        }
    }
}
