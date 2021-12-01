using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult<GenreShortDto>> GetAll()
        {
            var genre = await _genreRepository.GetAll() ;

            return Ok(genre);
        }

        [HttpGet("{id}")]
        public ActionResult<GenreLongDto> Get([FromRoute] int id)
        {
            var genre = _genreRepository.GetSingle(id);

            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlaylist([FromBody] GenreCreateDto dto)
        {
            var id = await _genreRepository.Add(dto);

            return Created($"/genre/{id}", null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _genreRepository.Delete(id);

            return NoContent();
        }

        //[HttpPatch("{id}")]
        //public ActionResult<GenreUpdateDto> Update([FromRoute] int id, [FromBody] GenreUpdateDto dto)
        //{
        //    _genreRepository.Update(dto, id);

        //    return Ok();
        //}
    }
}
