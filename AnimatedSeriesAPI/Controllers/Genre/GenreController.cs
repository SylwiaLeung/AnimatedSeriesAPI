using AnimatedSeriesAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    /// <summary>
    /// Genre API controller offers GET, POST, PATCH, DELETE request methods
    /// </summary>
    [Route("api/genres")]
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

        /// <summary>
        /// GET method returns all genres
        /// </summary>
        /// <returns>Returns list of GenreShortDtos</returns>
        /// <response code="200">Returns dtos for all genres in databse</response> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreShortDto>>> GetAllGenre()
        {
            return Ok(await _genreRepository.GetAll());
        }

        /// <summary>
        /// GET method return genre specified by id
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>Returns specified GenreLongDto</returns>
        /// <response code="200">Returns specifed genre's dto</response>
        [HttpGet("{genreId}")]
        public async Task<ActionResult<GenreLongDto>> GetGenre([FromRoute] int genreId)
        {
            var genre = await _genreRepository.GetSingle(genreId);

            return Ok(genre);
        }

        /// <summary>
        /// DELETE method delete specifed genre from database
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>Return 204 NoContent</returns>
        /// <response code="204">Returns no content</response>
        [HttpDelete("{genreId}")]
        public async Task<ActionResult> DeleteGenre([FromRoute] int genreId)
        {
            await _genreRepository.Delete(genreId);

            return NoContent();
        }

        /// <summary>
        /// POST method add new Genre to database
        /// </summary>
        /// <param name="genreCreateDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "New Genre"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new genre</response>

        [HttpPost]
        public async Task<ActionResult> CreateGenre(GenreCreateDto genreCreateDto)
        {
            int newDirectorId = await _genreRepository.Add(genreCreateDto);
            return Created($"/genre/{newDirectorId}", null);
        }

        /// <summary>
        /// PATCH method partial update of specifed genre
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="patchDoc"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /Todo
        ///     [
        ///       {
        ///         "op":"replace",
        ///         "path":"/Name",
        ///         "value": "Anime Test"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>
        [HttpPatch("{genreId}")]
        public async Task<ActionResult> UpdateGenre(JsonPatchDocument<GenreUpdateDto> patchDoc, int genreId)
        {
            var genreToUpdate = await _genreRepository.GetById(genreId);

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
