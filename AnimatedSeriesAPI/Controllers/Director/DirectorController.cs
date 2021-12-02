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

        [HttpGet]
        //[Route("directors")]
        public async Task<ActionResult<IEnumerable<DirectorShortDto>>> GetAllDirectors()
        {
            return Ok(await _directorRepo.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DirectorLongDto>> GetDirector(int id)
        {
            return Ok(await _directorRepo.GetSingle(id));
        }


        [HttpGet]
        [Route("{directorId}/seasons")]
        public async Task<ActionResult<IEnumerable<SeasonShortDto>>> GetDirectorAllSeasons(int directorId)
        {
            return Ok(await _directorRepo.GetDirectorAllSeasons(directorId));
        }

        [HttpPost]
        //[Route("directors")]
        public async Task<ActionResult> CreateDirector(DirectorCreateDto directorCreateDto)
        {
            int newDirectorId = await _directorRepo.Add(directorCreateDto);
            return Created($"/directors/{newDirectorId}", null);
        }

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
