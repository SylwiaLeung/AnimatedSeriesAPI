using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.DTO;
using AnimatedSeriesAPI.Models.DTO.Director;
using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers.Director
{
    /// <summary>
    /// Director API controller offers GET, POST, PATCH, DELETE request methods
    /// </summary>
    [Route("api/directors")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private IDirectorRepository _directorRepo;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorRepository directorRepo, IMapper mapper)
        {
            _directorRepo = directorRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// GET method returns all directors
        /// </summary>
        /// <returns>Returns list of DirectorShortDtos</returns>
        /// <response code="200">Returns dtos for all directors in databse</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorShortDto>>> GetAllDirectors()
        {
            return Ok(await _directorRepo.GetAll());
        }

        /// <summary>
        /// GET method return director specified by id
        /// </summary>
        /// <param name="directorId"></param>
        /// <returns>Returns specified DirectorLongDto</returns>
        /// <response code="200">Returns specifed director's dto</response>
        [HttpGet]
        [Route("{directorId}")]
        public async Task<ActionResult<DirectorLongDto>> GetDirector(int directorId)
        {
            return Ok(await _directorRepo.GetSingle(directorId));
        }

        /// <summary>
        /// GET method return season list of specifed director's seasons
        /// </summary>
        /// <param name="directorId"></param>
        /// <returns>Return list of SeasonShortDto</returns>
        /// <response code="200">Returns list of specifed director's seasons dtos</response>
        [HttpGet]
        [Route("{directorId}/seasons")]
        public async Task<ActionResult<IEnumerable<SeasonShortDto>>> GetDirectorAllSeasons(int directorId)
        {
            return Ok(await _directorRepo.GetDirectorAllSeasons(directorId));
        }

        /// <summary>
        /// POST method add new Director to database
        /// </summary>
        /// <param name="directorCreateDto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "New Director"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new director</response>
        [HttpPost]
        public async Task<ActionResult> CreateDirector(DirectorCreateDto directorCreateDto)
        {
            int newDirectorId = await _directorRepo.Add(directorCreateDto);
            return Created($"/directors/{newDirectorId}", null);
        }

        /// <summary>
        /// DELETE method delete specifed director from database
        /// </summary>
        /// <param name="directorId"></param>
        /// <returns>Return 204 NoContent</returns>
        /// <response code="204">Returns no content</response>
        [HttpDelete]
        [Route("{directorId}")]
        public async Task<ActionResult> DeleteDirector(int directorId)
        {
            await _directorRepo.Delete(directorId);
            return NoContent();
        }


        /// <summary>
        /// PATCH method partial update of specifed director
        /// </summary>
        /// <param name="directorId"></param>
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
        ///         "value": "Endrju Wajda Test"
        ///       }
        ///     ]
        /// </remarks>
        /// <response code="204">Returns no content</response>
        [HttpPatch]
        [Route("{directorId}")]
        public async Task<ActionResult> UpdateDirector(int directorId, JsonPatchDocument<DirectorUpdateDto> patchDoc )
        {
            var directorToUpdate = await _directorRepo.GetById(directorId);

            DirectorUpdateDto directorToPatch = _mapper.Map<DirectorUpdateDto>(directorToUpdate); 

            patchDoc.ApplyTo(directorToPatch, ModelState);
            if (!TryValidateModel(directorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(directorToPatch, directorToUpdate);
            await _directorRepo.Update(directorToUpdate);

            return NoContent();
        }


    }
}
