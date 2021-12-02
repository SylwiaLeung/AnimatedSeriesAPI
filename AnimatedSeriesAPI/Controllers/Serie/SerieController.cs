using AnimatedSeriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly ISerieRepository _daoService;

        public SerieController(ISerieRepository daoService)
        {
            _daoService = daoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SerieShortDto>>> GetAllSeries()
        {
            var serieDtos = await _daoService.GetAll();

            return Ok(serieDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SerieLongDto>> GetSingleSerie([FromRoute] int id)
        {
            var serieDto = await _daoService.GetSingle(id);

            return Ok(serieDto);
        }

        [HttpGet("{id}/Season")]
        public async Task<ActionResult<IEnumerable<SerieShortDto>>> GetAllSeasons([FromRoute] int id)
        {
            var serieDtos = await _daoService.GetAllSeasons(id);

            return Ok(serieDtos);
        }

        [HttpGet("{serieId}/season/{SeasonId}")]
        public async Task<ActionResult<SerieLongDto>> GetSingleSeason([FromRoute] int serieId, [FromRoute] int seasonId)
        {
            var serieDto = await _daoService.GetSingleSeason(serieId, seasonId);

            return Ok(serieDto);
        }
    }
}