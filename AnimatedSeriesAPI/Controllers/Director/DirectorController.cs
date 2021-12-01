using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
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
        [Route("directors/{directorId}/seasons")]
        public async Task<ActionResult<IEnumerable<SeasonShortDto>>> GetDirectorAllSeasons(int directorId)
        {
            return Ok(await _directorRepo.GetDirectorAllSeasons(directorId));
        }




    }
}
