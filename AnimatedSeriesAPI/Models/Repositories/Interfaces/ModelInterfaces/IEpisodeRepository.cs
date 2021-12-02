using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Models.DTO.Episode;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IEpisodeRepository :
        IEditableRepository<Episode,EpisodeCreateDto>,
        IReadableRepository<EpisodeLongDto, EpisodeShortDto>
    {
        Task<IEnumerable<EpisodeShortDto>> GetAll(int serieId, int seasonId);
        Task<EpisodeLongDto> GetSingle(int serieId, int seasonId, int episodeId);
    }
}
