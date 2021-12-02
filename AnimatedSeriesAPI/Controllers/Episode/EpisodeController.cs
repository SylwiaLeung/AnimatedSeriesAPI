using AnimatedSeriesAPI.Models;
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<SerieLongDto>> GetSingleSerie([FromRoute] int id)
        //{
        //    var serieDto = await _daoService.GetSingle(id);

        //    return Ok(serieDto);
        //}

        //[HttpGet("{id}/season")]
        //public async Task<ActionResult<IEnumerable<SerieShortDto>>> GetAllSeasons([FromRoute] int id)
        //{
        //    var serieDtos = await _daoService.GetAllSeasons(id);

        //    return Ok(serieDtos);
        //}

        //[HttpGet("{serieId}/season/{seasonId}")]
        //public async Task<ActionResult<SerieLongDto>> GetSingleSeason([FromRoute] int serieId, [FromRoute] int seasonId)
        //{
        //    var serieDto = await _daoService.GetSingleSeason(serieId, seasonId);

        //    return Ok(serieDto);
        //}
    }
}