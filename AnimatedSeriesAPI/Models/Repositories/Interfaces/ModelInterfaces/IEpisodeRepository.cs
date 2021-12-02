using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<EpisodeShortDto>> GetAll(int serieId, int seasonId);
        Task<EpisodeLongDto> GetSingle(int serieId, int seasonId, int episodeId);
    }
}
