using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface ISerieRepository
    {
        Task<SerieLongDto> GetSingle(int serieId);
        Task<PagedResult<SerieLongDto>> GetAll(SeriesQuery query);
        Task<SeasonLongDto> GetSingleSeason(int serieId, int seasonId);
        Task<IEnumerable<SeasonShortDto>> GetAllSeasons(int serieId);
    }
}
