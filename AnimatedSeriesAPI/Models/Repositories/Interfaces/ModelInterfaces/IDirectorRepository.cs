using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IDirectorRepository : IReadableRepository<DirectorLongDto,DirectorShortDto>
    {
        Task<IEnumerable<SeasonShortDto>> GetDirectorAllSeasons(int directorId);
    }
}
