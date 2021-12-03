using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Models.DTO.Director;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IDirectorRepository :
        IReadableRepository<DirectorLongDto, DirectorShortDto>,
        IEditableRepository<Director, DirectorCreateDto>
    {
        Task<IEnumerable<SeasonShortDto>> GetDirectorAllSeasons(int directorId);
        Task<Director> GetById(int id);
    }
}
