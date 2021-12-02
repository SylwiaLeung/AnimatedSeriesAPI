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

        /// <summary>
        /// GET method returns all seasons
        /// </summary>
        /// <returns>Returns list of SeasonShortDto</returns>
        /// <response code="200">Returns dtos for all seasons in databse</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeasonShortDto>>> GetAllSeasons()
        {
            var seasonDtos = await _daoService.GetAll();

            return Ok(seasonDtos);
        }

        /// <summary>
        /// GET method return season specified by id
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns>Returns specified SeasonLongDto</returns>
        /// <response code="200">Returns specifed season's dto</response>
        [HttpGet("{seasonId}")]
        public async Task<ActionResult<SeasonLongDto>> GetSingleSeason([FromRoute] int seasonId)
        {
            var seasonDto = await _daoService.GetSingle(seasonId);

            return Ok(seasonDto);
        }
    }
}