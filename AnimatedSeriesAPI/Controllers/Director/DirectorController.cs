using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.DTO.Director;
using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers.Director
{
    [ApiController]
    [Route("api/")]
    public class DirectorController : ControllerBase
    {
        private IDirectorRepository _directorRepo;

        public DirectorController(IDirectorRepository directorRepo)
        {
            _directorRepo = directorRepo;
        }

        [HttpGet]
        [Route("directors")]
        public async Task<ActionResult<IEnumerable<DirectorShortDto>>> GetAllDirectors()
        {
            return Ok(await _directorRepo.GetAll());
        }

        [HttpGet]
        [Route("directors/{id}")]
        public async Task<ActionResult<DirectorLongDto>> GetDirector(int id)
        {
            return Ok(await _directorRepo.GetSingle(id));
        }


        [HttpGet]
        [Route("directors/{directorid}/seasons")]
        public async Task<ActionResult<IEnumerable<SeasonShortDto>>> GetDirectorAllSeasons(int directorId)
        {
            return Ok(await _directorRepo.GetDirectorAllSeasons(directorId));
        }

        [HttpPost]
        [Route("directors")]
        public async Task<ActionResult> CreateDirector(DirectorCreateDto directorCreateDto)
        {
            int newDirectorId = await _directorRepo.Add(directorCreateDto);
            return Created($"/directors/{newDirectorId}", null);
        }

        [HttpDelete]
        [Route("directors/{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            return NoContent();
        }



        [HttpPatch]
        [Route("directors/{id}")]
        public async Task<ActionResult> UpdateDirector(int id, JsonPatchDocument<DirectorUpdateDto> patchDoc )
        {
            await _directorRepo.Update(patchDoc, id);
            return NoContent();
        }


    }
}
