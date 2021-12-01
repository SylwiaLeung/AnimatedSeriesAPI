using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreShortDto>>> GetAll()
        {
            var genre = await _genreRepository.GetAll() ;

            return Ok(genre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreLongDto>> Get([FromRoute] int id)
        {
            var genre = await _genreRepository.GetSingle(id);

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

        [HttpDelete("{id}")]
        public ActionResult<GenreUpdateDto> Update([FromRoute] int id, [FromBody] GenreUpdateDto dto)
        {
            _genreRepository.Update(dto, id);

            return Ok();
        }
    }
}
