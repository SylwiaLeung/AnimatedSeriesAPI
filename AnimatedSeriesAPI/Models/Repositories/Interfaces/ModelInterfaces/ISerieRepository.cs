using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface ISerieRepository : IReadableRepository<SerieLongDto, SerieShortDto>
    {
        Task<SeasonLongDto> GetSingleSeason(int serieId, int seasonId);
        Task<IEnumerable<SeasonShortDto>> GetAllSeasons(int serieId);
    }
}
