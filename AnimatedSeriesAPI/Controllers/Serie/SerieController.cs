using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    /// <summary>
    /// Serie API controller offers GET request methods
    /// </summary>
    [Route("api/series")]
    [ApiController]
    [Authorize]
    public class SerieController : ControllerBase
    {
        private readonly ISerieRepository _daoService;

        public SerieController(ISerieRepository daoService)
        {
            _daoService = daoService;
        }


        /// <summary>
        /// GET method returns all series
        /// </summary>
        /// <returns>Returns list of SerieShortDtos</returns>
        /// <response code="200">Returns dtos for all series in databse</response>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<PagedResult<SerieShortDto>>> GetAllSeries([FromQuery] SeriesQuery query)
        {
            var serieDtos = await _daoService.GetAll(query);

            return Ok(serieDtos);
        }

        /// <summary>
        /// GET method return serie specified by id
        /// </summary>
        /// <param name="serieId"></param>
        /// <returns>Returns specified SerieLongDto</returns>
        /// <response code="200">Returns specifed serie's dto</response>
        [HttpGet("{serieId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<SerieLongDto>> GetSingleSerie([FromRoute] int serieId)
        {
            var serieDto = await _daoService.GetSingle(serieId);

            return Ok(serieDto);
        }

        /// <summary>
        /// GET method returns all season for specified serie by id
        /// </summary>
        /// <returns>Returns list of SeasonShortDto</returns>
        /// <response code="200">Returns dtos for all sesons in specified serie</response>
        [HttpGet("{serieId}/season")]
        public async Task<ActionResult<IEnumerable<SeasonShortDto>>> GetAllSeasons([FromRoute] int serieId)
        {
            var serieDtos = await _daoService.GetAllSeasons(serieId);

            return Ok(serieDtos);
        }

        /// <summary>
        /// GET method returns specified seson by id for specified serie by id
        /// </summary>
        /// <returns>Returns SeasonLongDto</returns>
        /// <response code="200">Returns season specified by id in specified serie</response>
        [HttpGet("{serieId}/season/{seasonId}")]
        public async Task<ActionResult<SeasonLongDto>> GetSingleSeason([FromRoute] int serieId, [FromRoute] int seasonId)
        {
            var sesonDto = await _daoService.GetSingleSeason(serieId, seasonId);

            return Ok(sesonDto);
        }
    }
}