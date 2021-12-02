using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.DTO.Episode;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    [Route("api/Serie/{serieId}/Season/{seasonId}/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeRepository _daoService;

        public EpisodeController(IEpisodeRepository daoService)
        {
            _daoService = daoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeShortDto>>> GetAllEpisodes([FromRoute] int serieId, [FromRoute] int seasonId)
        {
            var episodeDtos = await _daoService.GetAll(serieId, seasonId);

            return Ok(episodeDtos);
        }

        [HttpGet("{episodeId}")]
        public async Task<ActionResult<EpisodeLongDto>> GetSingleEpisode([FromRoute] int serieId, [FromRoute] int seasonId, [FromRoute] int episodeId)
        {
            var serieDto = await _daoService.GetSingle(serieId, seasonId, episodeId);

            return Ok(serieDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEpisode([FromBody] EpisodeCreateDto episodeCreateDto)
        {
            int newEpisodeId = await _daoService.Add(episodeCreateDto);
            return Created($"/episodes/{newEpisodeId}", null);
        }

        [HttpDelete("{episodeId")]
        public async Task<ActionResult> DeleteDirector(int directorId)
        {
            await _daoService.Delete(directorId);
            return NoContent();
        }
    }
}
