using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    //[Route("api/season")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonRepository _daoService;

        public SeasonController(ISeasonRepository daoService)
        {
            _daoService = daoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeasonLongDto>>> GetAllSeasons()
        {
            var seasonDtos = await _daoService.GetAll();

            return Ok(seasonDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonLongDto>> GetSingleSeason([FromRoute] int id)
        {
            var seasonDto = await _daoService.GetSingle(id);

            return Ok(seasonDto);
        }
    }
}