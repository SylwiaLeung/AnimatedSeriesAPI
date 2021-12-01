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

        //[HttpDelete("{id}")]
        //public ActionResult<GenreUpdateDto> Update([FromRoute] int id, [FromBody] GenreUpdateDto dto)
        //{
        //    _genreRepository.Update(dto, id);

        //    return Ok();
        //}



        //[HttpPatch("{id}")]
        //public async Task<ActionResult> PartialGenreUpdate(JsonPatchDocument<GenreUpdateDto> patchDoc, int id)
        //{
        //    var genreModel = await _genreRepository.GetSingle(id);


        //    var authorToPatch = _mapper.Map<GenreUpdateDto>(genreModel);
        //    patchDoc.ApplyTo(authorToPatch, ModelState);
        //    if (!TryValidateModel(authorToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(authorToPatch, authorModel);
        //    await _authorRepo.UpdateAsync(authorModel);
        //    await _authorRepo.SaveAsync();

        //    return NoContent();
        //}
    }
}
