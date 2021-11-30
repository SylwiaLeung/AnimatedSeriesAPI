using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface ISerieRepository : IReadableRepository<SerieLongDto, SerieShortDto>
    {
        Task<SerieShortDto> GetSingleSeason(int serieId, int seasonId);
        Task<IEnumerable<SerieShortDto>> GetAllSeasons(int serieId);
    }
}
