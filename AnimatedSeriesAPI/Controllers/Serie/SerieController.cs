using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    [Route("serie")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly ISerieRepository _daoService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SerieShortDto>>> GetAllSeries()
        {
            var serieDtos = await _daoService.GetAll();

            return Ok(serieDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SerieLongDto>> GetSingleSerie([FromRoute] int serieId)
        {
            var serieDto = await _daoService.GetSingle(serieId);

            return Ok(serieDto);
        }

        [HttpGet("{id}/season")]
        public async Task<ActionResult<IEnumerable<SerieShortDto>>> GetAllSeasons([FromRoute] int serieId)
        {
            var serieDtos = await _daoService.GetAllSeasons(serieId);

            return Ok(serieDtos);
        }

        [HttpGet("{id}/season/{id}")]
        public async Task<ActionResult<SerieLongDto>> GetSingleSeason([FromRoute] int serieId, [FromRoute] int seasonId)
        {
            var serieDto = await _daoService.GetSingleSeason(serieId, seasonId);

            return Ok(serieDto);
        }
    }
}