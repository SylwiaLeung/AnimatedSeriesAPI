using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.DTO.Episode;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    [Route("api/series/{serieId}/seasons/{seasonId}/episodes")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeRepository _daoService;

        public EpisodeController(IEpisodeRepository daoService)
        {
            _daoService = daoService;
        }

        /// <summary>
        /// GET method return all episodes of specified serie and season
        /// </summary>
        /// <param name="serieId"></param>
        /// <param name="seasonId"></param>
        /// <returns>Returns list of EpisodeShortDto of specifed serie and season</returns>
        /// <response code="200">Returns list of EpisodeShortDto</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeShortDto>>> GetAllEpisodes([FromRoute] int serieId, [FromRoute] int seasonId)
        {
            var episodeDtos = await _daoService.GetAll(serieId, seasonId);

            return Ok(episodeDtos);
        }

        /// <summary>
        /// GET method return specified episode of specified serie and season
        /// </summary>
        /// <param name="serieId"></param>
        /// <param name="seasonId"></param>
        /// <param name="episodeId"></param>
        /// <returns>Returns EpisodeLongDto of specifed serie and season</returns>
        /// <response code="200">Returns EpisodeLongDto</response>
        [HttpGet("{episodeId}")]
        public async Task<ActionResult<EpisodeLongDto>> GetSingleEpisode([FromRoute] int serieId, [FromRoute] int seasonId, [FromRoute] int episodeId)
        {
            var serieDto = await _daoService.GetSingle(serieId, seasonId, episodeId);

            return Ok(serieDto);
        }

        /// <summary>
        /// POST method add new Episode of specified serie and season to database
        /// </summary>
        /// <param name="episodeCreateDto"></param>
        /// <param name="seasonId"></param>
        /// <returns>Returns endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "Title": "New Episode",
        ///        "EpisodeNumber": 33
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new episode</response>
        [HttpPost]
        public async Task<ActionResult> CreateEpisode([FromBody] EpisodeCreateDto episodeCreateDto, [FromRoute] int seasonId)
        {
            int newEpisodeId = await _daoService.Add(episodeCreateDto, seasonId);
            return Created($"/episodes/{newEpisodeId}", null);
        }


        /// <summary>
        /// DELETE method delete specifed episode from database
        /// </summary>
        ///  <param name="serieId"></param>
        ///  <param name="seasonId"></param>
        ///  <param name="episodeId"></param>
        /// <returns>Returns 204 NoContent</returns>
        /// <response code="204">Returns no content</response>
        [HttpDelete("{episodeId}")]
        public async Task<ActionResult> DeleteEpisode([FromRoute] int serieId, [FromRoute] int seasonId, [FromRoute] int episodeId)
        {
            await _daoService.Delete(serieId, seasonId, episodeId);
            return NoContent();
        }
    }
}
