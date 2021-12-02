using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _genreRepository.Delete(id);

            return NoContent();
        }



        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialGenreUpdate(JsonPatchDocument<GenreUpdateDto> patchDoc, int id)
        {
            await _genreRepository.Update(patchDoc, id);

            return NoContent();
        }
    }
}
