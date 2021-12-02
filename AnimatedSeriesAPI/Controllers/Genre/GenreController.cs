using AnimatedSeriesAPI.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreShortDto>>> GetAllGenre()
        {
            var genre = await _genreRepository.GetAll() ;

            return Ok(genre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreLongDto>> GetGenre([FromRoute] int id)
        {
            var genre = await _genreRepository.GetSingle(id);

            return Ok(genre);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre([FromRoute] int id)
        {
            await _genreRepository.Delete(id);

            return NoContent();
        }


        [HttpPost]
        //[Route("Genres")]
        public async Task<ActionResult> CreateGenre(GenreCreateDto genreCreateDto)
        {
            int newDirectorId = await _genreRepository.Add(genreCreateDto);
            return Created($"/genre/{newDirectorId}", null);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateGenre(JsonPatchDocument<GenreUpdateDto> patchDoc, int id)
        {
            var genreToUpdate = await _genreRepository.GetById(id);

            GenreUpdateDto genreToPathDto = _mapper.Map<GenreUpdateDto>(genreToUpdate);


            patchDoc.ApplyTo(genreToPathDto, ModelState);
            if (!TryValidateModel(genreToPathDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(genreToPathDto, genreToUpdate);
            await _genreRepository.Update(genreToUpdate);

            return NoContent();
        }
    }
}
