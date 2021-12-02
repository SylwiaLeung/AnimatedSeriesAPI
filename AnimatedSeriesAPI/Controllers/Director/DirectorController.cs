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
    [Route("api/[controller]")]
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
        /// <returns>Return list of DirectorShortDtos and 200 OK</returns>
        [HttpGet]
        //[Route("directors")]
        public async Task<ActionResult<IEnumerable<DirectorShortDto>>> GetAllDirectors()
        {
            return Ok(await _directorRepo.GetAll());
        }
        
        /// <summary>
        /// GET method return director specified by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return specified DirectorLongDto and 200 Ok</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DirectorLongDto>> GetDirector(int id)
        {
            return Ok(await _directorRepo.GetSingle(id));
        }

        /// <summary>
        /// GET method return season list of specifed director
        /// </summary>
        /// <param name="directorId"></param>
        /// <returns>Return list of SeasonShortDto and 200 Ok</returns>
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
        /// <returns>Return endpoint to new object and 201 Created</returns>
        [HttpPost]
        //[Route("directors")]
        public async Task<ActionResult> CreateDirector(DirectorCreateDto directorCreateDto)
        {
            int newDirectorId = await _directorRepo.Add(directorCreateDto);
            return Created($"/directors/{newDirectorId}", null);
        }

        /// <summary>
        /// DELETE method 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> 204 NoContent</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            await _directorRepo.Delete(id);
            return NoContent();
        }



        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult> UpdateDirector(int id, JsonPatchDocument<DirectorUpdateDto> patchDoc )
        {
            var directorToUpdate = await _directorRepo.GetById(id);

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
